// <copyright file="Level.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace SharpLog.Settings
{
    /// <summary>
    /// Class containing the settings for the <see cref="Level"/>.
    /// </summary>
    public class Level
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        public Level()
            : this('-', true, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Level"/> class.
        /// </summary>
        /// <param name="short">The short for the log level.</param>
        /// <param name="enabled">if set to <c>true</c> the level is enabled.</param>
        /// <param name="format">The format.</param>
        public Level(
            char @short = '-',
            bool enabled = true,
            string format = null)
        {
            this.Short = @short;
            this.Enabled = enabled;
            this.Format = format;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Level"/> is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets the format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets a char representing the log level.
        /// </summary>
        /// <value>
        /// The short.
        /// </value>
        public char Short { get; set; }
    }
}