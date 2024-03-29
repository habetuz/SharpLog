﻿// <copyright file="LevelContainer.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

namespace SharpLog.Settings
{
    /// <summary>
    /// Container for all log level specific settings.
    /// </summary>
    public class LevelContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LevelContainer"/> class.
        /// </summary>
        public LevelContainer()
            : this(null, null, null, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelContainer"/> class.
        /// </summary>
        /// <param name="debug">The debug settings.</param>
        /// <param name="trace">The trace settings.</param>
        /// <param name="info">The information settings.</param>
        /// <param name="warning">The warning settings.</param>
        /// <param name="error">The error settings.</param>
        /// <param name="fatal">The fatal settings.</param>
        public LevelContainer(
            Level? debug = null,
            Level? trace = null,
            Level? info = null,
            Level? warning = null,
            Level? error = null,
            Level? fatal = null)
        {
            this.Debug = debug;
            this.Trace = trace;
            this.Info = info;
            this.Warning = warning;
            this.Error = error;
            this.Fatal = fatal;
        }

        /// <summary>
        /// Gets or sets the settings for the log level "debug".
        /// </summary>
        /// <value>
        /// The debug.
        /// </value>
        public Level? Debug { get; set; }

        /// <summary>
        /// Gets or sets the settings for the log level "trace".
        /// </summary>
        /// <value>
        /// The trace.
        /// </value>
        public Level? Trace { get; set; }

        /// <summary>
        /// Gets or sets the settings for the log level "info".
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        public Level? Info { get; set; }

        /// <summary>
        /// Gets or sets the settings for the log level "info".
        /// </summary>
        /// <value>
        /// The warning.
        /// </value>
        public Level? Warning { get; set; }

        /// <summary>
        /// Gets or sets the settings for the log level "error".
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        public Level? Error { get; set; }

        /// <summary>
        /// Gets or sets the settings for the log level "fatal".
        /// </summary>
        /// <value>
        /// The fatal.
        /// </value>
        public Level? Fatal { get; set; }

        /// <summary>
        /// Gets the settings for a level.
        /// </summary>
        /// <param name="level">The level the settings should be returned from.</param>
        /// <returns>The requested settings.</returns>
        public Level? GetLevel(LogLevel level)
        {
            return level switch
            {
                LogLevel.Debug => this.Debug,
                LogLevel.Trace => this.Trace,
                LogLevel.Info => this.Info,
                LogLevel.Warning => this.Warning,
                LogLevel.Error => this.Error,
                LogLevel.Fatal => this.Fatal,
                _ => null,
            };
        }
    }
}