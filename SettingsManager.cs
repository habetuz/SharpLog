using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpLog.Settings;
using SharpLog.Outputs;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.IO;
using System.Security;
using YamlDotNet.Core;
using System.Runtime.Serialization;

namespace SharpLog
{
    public static class SettingsManager
    {
        public static BaseSettings Settings { get; set; }

        public static void ReloadSettings(bool fromFile = true)
        {
            Settings = new BaseSettings();

            if (!fromFile) return;
            // Load Settings from file
            try
            {
                IDeserializer deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();

                string file = System.IO.Path.Combine(Environment.CurrentDirectory, "sharplog.yml");
                Settings = deserializer.Deserialize<BaseSettings>(File.ReadAllText(file));
                if (Settings == null)
                {
                    Settings = new BaseSettings();
                }
            }
            catch (Exception ex)
            {
                if (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    Logging.LogWarning("Settings file (sharplog.yml) not found, using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                }
                else if (ex is UnauthorizedAccessException || ex is SecurityException)
                {
                    Logging.LogWarning("Settings file (sharplog.yml) not accessible, using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                }
                else if (ex is YamlException)
                {
                    Logging.LogWarning("Settings file is invalid, using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE", ex.GetBaseException());
                }
                else
                {
                    Logging.LogError("Settings file not readable, using default settings." , typeof(SettingsManager), "SHARPLOG-INITIALIZE", ex);
                }

                return;
            }

            // Validate settings
            if (Settings.Tags == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"tags\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }
            
            if (Settings.Outputs == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"outputs\" set to \"null\". Remove property or provide valid arguments. Using default settings.",typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            if (Settings.Levels == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            if (Settings.Format == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"format\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }
            
            if (Settings.Levels.Debug == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.debug\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            if (Settings.Levels.Trace == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.trace\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            if (Settings.Levels.Info == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.info\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            if (Settings.Levels.Warn == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.warn\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            if (Settings.Levels.Error == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.error\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            if (Settings.Levels.Fatal == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.fatal\" set to \"null\". Remove property or provide valid arguments. Using default settings.", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
                return;
            }

            Logging.LogInfo("Settings file loaded successfully!", typeof(SettingsManager), "SHARPLOG-INITIALIZE");
        }
    }
}
