// <copyright file="Output.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using SharpLog.Settings;

namespace SharpLog.Outputs
{
    /// <summary>
    /// Base class for all outputs.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public abstract class Output
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Output"/> class.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="levels">The level settings.</param>
        protected Output(string? format = null, LevelContainer? levels = null)
        {
            this.Format = format;
            this.Levels = levels;
        }

        /// <summary>
        /// Gets or sets the format for the output.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public string? Format { get; set; }

        /// <summary>
        /// Gets or sets the level settings for the output.
        /// </summary>
        /// <value>
        /// The levels.
        /// </value>
        public LevelContainer? Levels { get; set; }

        /// <summary>
        /// Writes the specified formatted log.
        /// </summary>
        /// <param name="formattedLog">The formatted log.</param>
        /// <param name="log">The log information.</param>
        public abstract void Write(string formattedLog, Log log);

        /// <summary>
        /// Writes the specified log.
        /// </summary>
        /// <param name="log">The log.</param>
        internal void Write(Log log)
        {
            if (this.Format != null)
            {
                log.Format = this.Format;
            }

            if (this.Levels?.GetLevel(log.Level) != null)
            {
                Level levelSettings = this.Levels.GetLevel(log.Level)!;

                if (!levelSettings.Enabled)
                {
                    return;
                }

                log.LevelSettings = levelSettings;

                if (levelSettings.Format != null)
                {
                    log.Format = levelSettings.Format;
                }
            }

            this.Write(Formatter.Format(log), log);
        }
    }
}
