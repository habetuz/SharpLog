// <copyright file="Formatter.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

namespace SharpLog
{
    using System.Reflection;

    /// <summary>
    /// Class for formatting <see cref="Log"/> objects.
    /// </summary>
    internal class Formatter
    {
        /// <summary>
        /// Formats the specified log with an alternative format.
        /// </summary>
        /// <param name="format">The alternative format.</param>
        /// <param name="log">The log.</param>
        /// <returns>The formattet log.</returns>
        internal static string Format(string format, Log log)
        {
            log = new Log()
            {
                Class = log.Class,
                Exception = log.Exception,
                Format = format,
                Level = log.Level,
                LevelSettings = log.LevelSettings,
                Message = log.Message,
                StackTrace = log.StackTrace,
                Tag = log.Tag,
                Time = log.Time,
            };

            return Format(log);
        }

        /// <summary>
        /// Formats the specified log.
        /// </summary>
        /// <param name="log">The log.</param>
        /// <returns>The formattet log.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1005:Single line comments should begin with single space", Justification = "Needed for formatting")]
        internal static string Format(Log log)
        {
            string format = log.Format;
            format = format.Replace("\\n", System.Environment.NewLine);
            string output = string.Empty;

            // Iterate through format
            for (int i = 0; i < format.Length; i++)
            {
                // Add to output if not a placeholder
                if (format[i] != '$')
                {
                    output += format[i];
                }

                // Format placeholder
                else
                {
                    /*     ˅ Get here
                     * ...$D...
                     */
                    i++;
                    if (i >= format.Length)
                    {
                        i--;
                    }

                    switch (format[i])
                    {
                        //   ...$$...
                        // > ...$...
                        case '$':
                            output += '$';
                            break;

                        // All following cases get format the following:
                        //   ...$Da{...}p{...}s{...}$...
                        // > ...[prefix (p)][value (time, log level, message, etc.)][suffix (s)]...
                        case 'D':
                            (string argument, string prefix, string suffix, string indentation, int index) = GetArguments(format, i);
                            i = index;
                            string date;
                            if (argument == string.Empty)
                            {
                                date = log.Time.ToString();
                            }
                            else
                            {
                                date = log.Time.ToString(argument);
                            }

                            output += $"{prefix}{indentation}{date}{suffix}";
                            break;
                        case 'L':
                            (argument, prefix, suffix, indentation, i) = GetArguments(format, i);
                            string logLevel;
                            switch (argument)
                            {
                                case "l":
                                    goto default;
                                case "s":
                                    logLevel = log.LevelSettings.Short.ToString();
                                    break;
                                default:
                                    logLevel = log.Level.ToString();
                                    break;
                            }

                            output += $"{prefix}{indentation}{logLevel}{suffix}";
                            break;
                        case 'T':
                            (_, prefix, suffix, indentation, i) = GetArguments(format, i);
                            if (log.Tag == null)
                            {
                                break;
                            }

                            output += $"{prefix}{indentation}{log.Tag}{suffix}";
                            break;
                        case 'M':
                            (_, prefix, suffix, indentation, i) = GetArguments(format, i);

                            var m = log.Message.ToString().Replace("\n", $"\n{indentation}");

                            output += $"{prefix}{indentation}{m}{suffix}";
                            break;
                        case 'C':
                            (_, prefix, suffix, indentation, i) = GetArguments(format, i);
                            if (log.Class == null)
                            {
                                break;
                            }

                            output += $"{prefix}{indentation}{log.Class}{suffix}";
                            break;

                        case 'F':
                            (argument, prefix, suffix, indentation, i) = GetArguments(format, i);
                            if (log.Function == null)
                            {
                                break;
                            }

                            switch (argument)
                            {
                                case "l":
                                    output += $"{prefix}{log.Function}{suffix}";
                                    break;
                                case "s":
                                    goto default;
                                default:
                                    output +=
                                        $"{prefix}" +
                                        $"{indentation}" +
                                        $"{log.Function.Name}{suffix}" +
                                        $"{(log.Function.IsGenericMethod ? "[...]" : string.Empty)}" +
                                        $"{(log.Function.GetParameters().Length > 0 ? "(...)" : "()")}";
                                    break;
                            }

                            break;
                        case 'E':
                            (_, prefix, suffix, indentation, i) = GetArguments(format, i);
                            if (log.Exception == null)
                            {
                                break;
                            }

                            output += prefix;

                            var exception = log.Exception;
                            int depth = 0;
                            do
                            {
                                if (depth > 0)
                                {
                                    output += "\n";
                                }

                                output += new string(' ', depth * 3);

                                output += $"{indentation}{exception.GetType().Name}: {exception.Message}";
                                exception = exception.InnerException;
                                depth++;
                            }
                            while (exception != null);

                            output += suffix;
                            break;
                        case 'S':
                            (_, prefix, suffix, indentation, i) = GetArguments(format, i);
                            if (log.StackTrace == null)
                            {
                                break;
                            }

                            var s = log.StackTrace.Replace("\n", $"\n{indentation}");
                            s = s.Remove(s.Length - 2);

                            output += $"{prefix}{indentation}{s}{suffix}";
                            break;
                        default:
                            char placeholder = format[i];
                            (_, prefix, suffix, indentation, i) = GetArguments(format, i);
                            output += $"${placeholder}:{prefix}{indentation}!UNKNOWN PLACEHOLDER!{suffix}$";
                            break;
                    }
                }
            }

            return output;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1005:Single line comments should begin with single space", Justification = "Needed for formatting")]
        private static (string argument, string prefix, string suffix, string indentation, int index) GetArguments(string format, int index)
        {
            string argument = string.Empty;
            string prefix = string.Empty;
            string suffix = string.Empty;
            string indentation = string.Empty;

            //      ˅ Get here
            // ...$D...
            //   ˅˅˅˅˅˅˅
            for (index++; index < format.Length && format[index] != '$'; index++)
            {
                switch (format[index])
                {
                    case 'a':
                        //                                           ˅ Get here
                        //                                       ...a{...
                        //                                       ˅˅˅˅˅˅˅˅˅
                        (argument, index) = GetSubstring(format, index + 1, '}');
                        break;
                    case 'p':
                        //                                         ˅ Get here
                        //                                     ...p{...
                        //                                     ˅˅˅˅˅˅˅˅˅
                        (prefix, index) = GetSubstring(format, index + 1, '}');
                        break;
                    case 's':
                        //                                         ˅ Get here
                        //                                     ...s{...
                        //                                     ˅˅˅˅˅˅˅˅˅
                        (suffix, index) = GetSubstring(format, index + 1, '}');
                        break;
                    case 'i':
                        //                                         ˅ Get here
                        //                                     ...i{...
                        //                                     ˅˅˅˅˅˅˅˅˅
                        (indentation, index) = GetSubstring(format, index + 1, '}');
                        break;
                    default:
                        string prePrefix = format[index] + "{";
                        (prefix, index) = GetSubstring(format, index + 1, '}');
                        prefix = $"{prePrefix}{prefix}}}";
                        break;
                }
            }

            return (argument, prefix, suffix, indentation, index);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1005:Single line comments should begin with single space", Justification = "Needed for formatting")]
        private static (string substring, int index) GetSubstring(string format, int from, char to)
        {
            string substring = string.Empty;

            //       ˅ Get here
            //   ...{...
            //   ˅˅˅˅˅˅
            for (from++; from < format.Length && format[from] != to; from++)
            {
                substring += format[from];
            }

            return (substring, from);
        }
    }
}
