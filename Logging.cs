using SharpLog.Settings;
using System;
using System.Threading;

namespace SharpLog
{
    public static class Logging
    {
        static Logging()
        {
            SettingsManager.ReloadSettings();
        }

        public static void Initialize() { }

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
                return;

            // Find output container
            // 1: Output container of tag
            // 2: General output container
            OutputContainer outputContainer = null;
            if (tagAvailable)
            {
                outputContainer = tagContainer.Outputs;
            }
            else if (outputContainer == null)
            {
                outputContainer = SettingsManager.Settings.Outputs;
            }

            // Find level
            // 1: Tag level
            // 2: General level
            Level levelSettings = null;
            bool levelSettingsFromTag = false;
            if (tagAvailable && tagContainer.Levels.GetLevel(level) != null)
            {
                levelSettings = tagContainer.Levels.GetLevel(level);
                levelSettingsFromTag = true;
            } 
            else
            {
                levelSettings = SettingsManager.Settings.Levels.GetLevel(level);
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
            outputContainer.Outputs.ForEach(output => output.Write(log));

            if (level == LogLevel.Fatal)
            {
                outputContainer.File?.Dispose();
                outputContainer.Outputs.ForEach(output => output.Dispose());
                Environment.Exit(1);
            }
        }

        public static void LogDebug(object message, Type @class, string tag = null, string stackTrace = null)
        {
            Log(LogLevel.Debug, message, @class, tag, null, stackTrace);
        }

        public static void LogTrace(object message, Type @class, string tag = null, string stackTrace = null)
        {
            Log(LogLevel.Trace, message, @class, tag, null, stackTrace);
        }

        public static void LogInfo(object message, Type @class, string tag = null, string stackTrace = null)
        {
            Log(LogLevel.Info, message, @class, tag, null, stackTrace);
        }

        public static void LogWarning(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Warn, message, @class, tag, exception, stackTrace);
        }

        public static void LogError(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Error, message, @class, tag, exception, stackTrace);
        }

        public static void LogFatal(object message, Type @class, string tag = null, Exception exception = null, string stackTrace = null)
        {
            Log(LogLevel.Fatal, message, @class, tag, exception, stackTrace);
        }

        public static void Dispose()
        {
            SettingsManager.Dispose();
        }
    }
}
