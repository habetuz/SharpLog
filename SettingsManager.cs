// <copyright file="SettingsManager.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System.Net;
using System.Security;
using SharpLog.Settings;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization.ObjectFactories;

namespace SharpLog
{
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
        public static BaseSettings? Settings { get; set; }

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
                Logging.LogInfo("Default settings loaded! [green]SharpLog ready[/].", "SHARPLOG_INTERNAL");
                return;
            }

            // Load Settings from file
            try
            {
                var defaultObjectFactory = new DefaultObjectFactory();
                IDeserializer deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .WithTypeMapping<ICredentialsByHost, NetworkCredential>()
                    .WithTypeMapping<Outputs.Output, Outputs.GenericOutput>()
                    .Build();

                string file = System.IO.Path.Combine(Environment.CurrentDirectory, "sharplog.yml");
                Settings = deserializer.Deserialize<BaseSettings>(File.ReadAllText(file));
            }
            catch (Exception ex)
            {
                ReloadSettings(false);
                if (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    Logging.LogWarning("Settings file (sharplog.yml) not found, [red]using default settings[/].", "SHARPLOG_INTERNAL", ex);
                }
                else if (ex is UnauthorizedAccessException || ex is SecurityException)
                {
                    Logging.LogWarning("Settings file (sharplog.yml) not accessible, [red]using default settings[/].", "SHARPLOG_INTERNAL", ex);
                }
                else if (ex is YamlException)
                {
                    Logging.LogWarning("Settings file is invalid, [red]using default settings[/].", "SHARPLOG_INTERNAL", ex);
                }
                else
                {
                    Logging.LogError("Settings file not readable, [red]using default settings[/].", "SHARPLOG_INTERNAL", ex);
                }

                return;
            }

            Logging.LogInfo("Settings file loaded successfully! [green]SharpLog ready[/].", "SHARPLOG_INTERNAL");
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
