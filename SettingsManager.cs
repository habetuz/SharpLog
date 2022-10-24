// <copyright file="SettingsManager.cs" company="Marvin Fuchs">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Security;
    using SharpLog.Settings;
    using YamlDotNet.Core;
    using YamlDotNet.Serialization;
    using YamlDotNet.Serialization.NamingConventions;
    using YamlDotNet.Serialization.ObjectFactories;

    /// <summary>
    /// Class responsible for managing the settings.
    /// </summary>
    public static class SettingsManager
    {
        static SettingsManager()
        {
            Logging.Initialize();
        }

        /// <summary>
        /// Gets or sets the settings.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        public static BaseSettings Settings { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        internal static bool IsDisposed { get; private set; }

        /// <summary>
        /// Reloads the settings.
        /// </summary>
        /// <param name="fromFile">if set to <c>true</c> the settings are loaded from the file "sharplog.yml" if possible.</param>
        public static void ReloadSettings(bool fromFile = true)
        {
            Settings?.Dispose();

            IsDisposed = false;

            if (!fromFile)
            {
                Settings = new BaseSettings();
                return;
            }

            // Load Settings from file
            try
            {
                var defaultObjectFactory = new DefaultObjectFactory();
                IDeserializer deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .WithTypeMapping<ICredentialsByHost, NetworkCredential>()
                    .Build();

                string file = System.IO.Path.Combine(Environment.CurrentDirectory, "sharplog.yml");
                Settings = deserializer.Deserialize<BaseSettings>(File.ReadAllText(file));
                if (Settings == null)
                {
                    Settings = new BaseSettings();
                }
            }
            catch (Exception ex)
            {
                Settings?.Dispose();
                Settings = new BaseSettings();
                if (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    Logging.LogWarning("Settings file (sharplog.yml) not found, using default settings.", "SHARPLOG_INTERNAL", ex);
                }
                else if (ex is UnauthorizedAccessException || ex is SecurityException)
                {
                    Logging.LogWarning("Settings file (sharplog.yml) not accessible, using default settings.", "SHARPLOG_INTERNAL", ex);
                }
                else if (ex is YamlException)
                {
                    Logging.LogWarning("Settings file is invalid, using default settings.", "SHARPLOG_INTERNAL", ex);
                }
                else
                {
                    Logging.LogError("Settings file not readable, using default settings.", "SHARPLOG_INTERNAL", ex);
                }

                return;
            }

            // Validate settings
            if (Settings.Tags == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"tags\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Outputs == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"outputs\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Levels == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Format == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"format\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Levels.Debug == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.debug\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Levels.Trace == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.trace\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Levels.Info == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.info\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Levels.Warning == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.warn\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Levels.Error == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.error\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            if (Settings.Levels.Fatal == null)
            {
                ReloadSettings(false);
                Logging.LogWarning("\"levels.fatal\" set to \"null\". Remove property or provide valid arguments. Using default settings.", "SHARPLOG_INTERNAL");
                return;
            }

            Logging.LogInfo("Settings file loaded successfully!", "SHARPLOG_INTERNAL");
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        internal static void Dispose()
        {
            if (IsDisposed)
            {
                return;
            }

            Settings?.Dispose();
            Settings = null;

            IsDisposed = true;
        }
    }
}
