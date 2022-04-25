// <copyright file="Logging.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace SharpLog
{
    using System;
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
        /// Logs a log.
        /// </summary>
        /// <param name="level">The level. If the level is <see cref="LogLevel.Fatal"/> the programm ends with code 0.</param>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public static void Log(LogLevel level, object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            if (SettingsManager.IsDisposed)
            {
                SettingsManager.ReloadSettings();
                LogWarning("SettingsManager was disposed, reloaded settings.", typeof(Logging), "SHARPLOG-INITIALIZATION");
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
            OutputContainer outputContainer = null;
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
            Level levelSettings = null;
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
            string format = null;
            if (levelSettingsFromTag && levelSettings.Format != null)
            {
                format = levelSettings.Format;
            }
            else if (tagAvailable && tagContainer.Format != null)
            {
                format = tagContainer.Format;
            }
            else
            {
                format = SettingsManager.Settings.Format;
            }

            Log log = new Log(level, message, @class, tag, exception, levelSettings, format, DateTime.Now, stackTrace);

            outputContainer.Console?.Write(log);
            outputContainer.File?.Write(log);
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

        /// <summary>
        /// Logs a debug log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public static void LogDebug(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Debug, message, @class, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a trace log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public static void LogTrace(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Trace, message, @class, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs an information log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public static void LogInfo(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Info, message, @class, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a warning log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public static void LogWarning(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Warn, message, @class, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs an error log.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public static void LogError(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Error, message, @class, tag, exception, stackTrace);
        }

        /// <summary>
        /// Logs a fatal log and exits the programm (with code 1).
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public static void LogFatal(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Fatal, message, @class, tag, exception, stackTrace);
        }

        /// <summary>
        /// Releases resources.
        /// </summary>
        public static void Dispose()
        {
            SettingsManager.Dispose();
        }
    }
}
