// <copyright file="Logging.cs" company="Marvin Fuchs">
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
    using System;
    using System.Diagnostics;
    using SharpLog.Settings;

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
        public static void LogDebug(object message, string tag = null, Exception exception = null, bool stackTrace = false)
        {
            Log(LogLevel.Debug, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a trace log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogTrace(object message, string tag = null, Exception exception = null, bool stackTrace = false)
        {
            Log(LogLevel.Trace, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs an information log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogInfo(object message, string tag = null, Exception exception = null, bool stackTrace = false)
        {
            Log(LogLevel.Info, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a warning log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogWarning(object message, string tag = null, Exception exception = null, bool stackTrace = false)
        {
            Log(LogLevel.Warn, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs an error log message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogError(object message, string tag = null, Exception exception = null, bool stackTrace = false)
        {
            Log(LogLevel.Error, message, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a fatal log message and exits the program with code 1.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">Wether the stack trace should be logged.</param>
        public static void LogFatal(object message, string tag = null, Exception exception = null, bool stackTrace = false)
        {
            Log(LogLevel.Fatal, message, tag, exception, stackTrace);
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
        internal static void Log(LogLevel level, object message, string tag = null, Exception exception = null, bool stackTrace = false)
        {
            if (SettingsManager.IsDisposed)
            {
                SettingsManager.ReloadSettings();
                LogWarning("SettingsManager was disposed, reloaded settings.", "SHARPLOG-INITIALIZATION");
            }

            // Check if the settings contain the specified tag
            Tag tagContainer = null;
            bool tagAvailable = tag != null && SettingsManager.Settings.Tags.ContainsKey(tag);
            if (tagAvailable)
            {
                tagContainer = SettingsManager.Settings.Tags[tag];
            }

            // Check if tag is enabled
            if (tagAvailable && !tagContainer.Enabled)
            {
                return;
            }

            // Find output container
            // 1: Output container of tag
            // 2: General output container
            OutputContainer outputContainer;
            if (tagAvailable && tagContainer.Outputs != null)
            {
                outputContainer = tagContainer.Outputs;
            }
            else
            {
                outputContainer = SettingsManager.Settings.Outputs;
            }

            // Find level
            // 1: Tag level
            // 2: General level
            Level levelSettings;
            bool levelSettingsFromTag = false;
            if (tagAvailable && tagContainer.Levels != null && tagContainer.Levels.GetLevel(level) != null)
            {
                levelSettings = tagContainer.Levels.GetLevel(level);
                levelSettingsFromTag = true;
            }
            else
            {
                levelSettings = SettingsManager.Settings.Levels.GetLevel(level);
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
            string format;
            if (levelSettingsFromTag && levelSettings.Format != null)
            {
                format = levelSettings.Format;
            }
            else if (tagAvailable && tagContainer.Format != null)
            {
                format = tagContainer.Format;
            }
            else if (levelSettings.Format != null)
            {
                format = levelSettings.Format;
            }
            else
            {
                format = SettingsManager.Settings.Format;
            }

            // Generate stack trace
            var stack = stackTrace ? new StackTrace(2, true) : new StackTrace(2, false);

            Log log = new Log(level, message, stack.GetFrame(0).GetMethod().DeclaringType, stack.GetFrame(0).GetMethod(), tag, exception, levelSettings, format, DateTime.Now, stackTrace ? stack.ToString() : null);

            outputContainer.Console?.Write(log);
            outputContainer.File?.Write(log);
            outputContainer.Email?.Write(log);
            foreach (var output in outputContainer.GetOutputs())
            {
                output.Write(log);
            }

            if (level == LogLevel.Fatal)
            {
                Dispose();
                Environment.Exit(1);
            }
        }
    }
}
