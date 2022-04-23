using System;

namespace SharpLog
{
    internal class Formatter
    {
        internal static string Format(Log log)
        {
            string format = log.Format;
            format = format.Replace("\\n", System.Environment.NewLine);
            string output = "";
            // Iterate through format
            for(int i = 0; i < format.Length; i++)
            {
                // Add to output if not a placeholder
                if (format[i] != '$')
                {
                    output += format[i];
                }
                // Format placeholder
                else
                {
                    //     ˅ Get here
                    // ...$D...
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
                            (string argument, string prefix, string suffix, int index) = GetArguments(format, i);
                            i = index;
                            string date;
                            if (argument == "")
                            {
                                date = log.Time.ToString();
                            } 
                            else
                            {
                                date = log.Time.ToString(argument);
                            }
                            output += $"{prefix}{date}{suffix}";
                            break;
                        case 'L':
                            (argument, prefix, suffix, i) = GetArguments(format, i);
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
                            output += $"{prefix}{logLevel}{suffix}";
                            break;
                        case 'T':
                            (_, prefix, suffix, i) = GetArguments(format, i);
                            
                            if (log.Tag == null) break;
                            output += $"{prefix}{log.Tag}{suffix}";
                            break;
                        case 'M':
                            (_, prefix, suffix, i) = GetArguments(format, i);
                            output += $"{prefix}{log.Message}{suffix}";
                            break;
                        case 'C':
                            (_, prefix, suffix, i) = GetArguments(format, i);
                            if (log.Class == null) break;
                            output += $"{prefix}{log.Class}{suffix}";
                            break;
                        case 'E':
                            (_, prefix, suffix, i) = GetArguments(format, i);
                            if (log.Exception == null) break;
                            output += $"{prefix}{log.Exception.GetType().Name}: {log.Exception.Message}{suffix}";
                            break;
                        case 'S':
                            (_, prefix, suffix, i) = GetArguments(format, i);
                            if (log.StackTrace == null) break;
                            output += $"{prefix}{log.StackTrace}{suffix}";
                            break;
                        default:
                            char placeholder = format[i];
                            (_, prefix, suffix, i) = GetArguments(format, i);
                            output += $"${placeholder}:{prefix}!UNKNOWN PLACEHOLDER!{suffix}$";
                            break;
                    }
                }
            }
            
            return output;
        }

        private static (string argument, string prefix, string suffix, int index) GetArguments(string format, int index)
        {
            string argument = "";
            string prefix = "";
            string suffix = "";
            //      ˅ Get here
            // ...$D...
            //   ˅˅˅˅˅˅˅
            for (index++; index < format.Length && format[index] != '$'; index++)
            {
                switch(format[index])
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
                    default:
                        string prePrefix = format[index] + "{";
                        (prefix, index) = GetSubstring(format, index + 1, '}');
                        prefix = $"{prePrefix}{prefix}}}";
                        break;
                }
            }

            return (argument, prefix, suffix, index);
        }

        private static (string substring, int index)  GetSubstring(string format, int from, char to)
        {
            string substring = "";
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
