// <copyright file="Logging.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System;
using System.Diagnostics;
using SharpLog.Settings;

namespace SharpLog
{
    /// <summary>
    /// Class responsible for logging.
    /// </summary>
    public static class Logging
    {
        static Logging()
        {
            SettingsManager.ReloadSettings();
        }

        /// <summary>
        /// Initializes the logger.
        /// </summary>
        public static void Initialize()
        {
        }

        /// <summary>
        /// Logs a debug log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogDebug(object message, string? tag = null, Exception? exception = null, bool stackTrace = false)
        {
            LogInternal(LogLevel.Debug, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a trace log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogTrace(object message, string? tag = null, Exception? exception = null, bool stackTrace = false)
        {
            LogInternal(LogLevel.Trace, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs an information log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogInfo(object message, string? tag = null, Exception? exception = null, bool stackTrace = false)
        {
            LogInternal(LogLevel.Info, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a warning log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogWarning(object message, string? tag = null, Exception? exception = null, bool stackTrace = false)
        {
            LogInternal(LogLevel.Warning, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs an error log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogError(object message, string? tag = null, Exception? exception = null, bool stackTrace = false)
        {
            LogInternal(LogLevel.Error, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a fatal log message and exits the program with code 1.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogFatal(object message, string? tag = null, Exception? exception = null, bool stackTrace = false)
        {
            LogInternal(LogLevel.Fatal, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Releases resources and logs all remaining logs. Should be called before exiting the program.
        /// </summary>
        public static void Dispose()
        {
            SettingsManager.Dispose();
        }

        /// <summary>
        /// Logs a log message containing the given information.
        /// </summary>
        /// <param name="level">The level. If the level is <see cref="LogLevel.Fatal"/> the program ends with code 0.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void Log(
            LogLevel level,
            object message,
            string? tag = null,
            Exception? exception = null,
            bool stackTrace = false)
        {
            LogInternal(
                level,
                message,
                tag,
                exception,
                stackTrace
            );
        }

        private static void LogInternal(
            LogLevel level,
            object message,
            string? tag = null,
            Exception? exception = null,
            bool stackTrace = false)
        {
            if (SettingsManager.IsDisposed)
            {
                SettingsManager.ReloadSettings();
                LogWarning("SettingsManager was disposed, reloaded settings.", "SHARPLOG-INITIALIZATION");
            }

            if (SettingsManager.Settings is null)
            {
                throw new NullReferenceException("SettingsManager.Settings should not be null here. This is a bug!");
            }

            string? format = SettingsManager.Settings.Format;

            // Check if the settings contain the specified tag
            Tag? tagContainer = null;
            if (tag is not null && SettingsManager.Settings.Tags is not null)
            {
                SettingsManager.Settings.Tags.TryGetValue(tag, out tagContainer);
                if (tagContainer?.Format is not null)
                {
                    format = tagContainer.Format;
                }
            }

            // Check if tag is enabled
            if (tagContainer?.Enabled == false)
            {
                return;
            }

            // Find output container
            // 1: Output container of tag
            // 2: General output container
            OutputContainer outputContainer;
            if (tagContainer?.Outputs is not null)
            {
                outputContainer = tagContainer.Outputs;
            }
            else
            {
                if (SettingsManager.Settings.Outputs is null)
                {
                    tag ??= "<null>";
                    LogTrace($"A log with the tag [yellow]{tag}[/] could not be logged because no tag or general output was specified.", "SHARPLOG_INTERNAL");
                    return;
                }

                outputContainer = SettingsManager.Settings.Outputs;
            }

            // Find level settings
            // 1: Tag level
            // 2: General level
            Level levelSettings = new();
            if (SettingsManager.Settings.Levels is not null)
            {
                var generalLevelSettings = SettingsManager.Settings.Levels.GetLevel(level);
                if (generalLevelSettings is not null)
                {
                    levelSettings.Enabled = generalLevelSettings.Enabled;
                    levelSettings.Short = generalLevelSettings.Short;
                    if (generalLevelSettings.Format is not null && tagContainer?.Format is not null)
                    {
                        format = generalLevelSettings.Format;
                    }
                }
            }

            if (!levelSettings.Enabled)
            {
                return;
            }

            if (tagContainer?.Levels != null)
            {
                var tagLevelSettings = tagContainer.Levels.GetLevel(level);
                if (tagLevelSettings is not null)
                {
                    levelSettings.Enabled = tagLevelSettings.Enabled;
                    levelSettings.Short = tagLevelSettings.Short == '\0' ? levelSettings.Short : tagLevelSettings.Short;
                    if (tagLevelSettings.Format is not null)
                    {
                        format = tagLevelSettings.Format;
                    }
                }
            }

            if (!levelSettings.Enabled)
            {
                return;
            }

            // Find format
            // 1: Format of level of tag
            // 2: Format of tag
            // 3: Format of general level
            // 4: General format
            if (format is null)
            {
                throw new NullReferenceException("No format was found! Check your settings.yml or your code if you set formats to <null>.");
            }

            // Generate stack trace
            var stack = stackTrace ? new StackTrace(2, true) : new StackTrace(2, false);

            Log log = new(
                level,
                message,
                stack!.GetFrame(0)!.GetMethod()!.DeclaringType!,
                stack!.GetFrame(0)!.GetMethod()!,
                tag!,
                exception!,
                levelSettings.Short,
                format,
                DateTime.Now,
                stackTrace ? stack.ToString() : null!);

            foreach (var output in outputContainer)
            {
                output.Write(log);
            }

            if (level != LogLevel.Fatal)
            {
                return;
            }

            Dispose();
            Environment.Exit(1);
        }
    }
}
