// <copyright file="Tag.cs" company="Marvin Fuchs">
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
    using System;

    /// <summary>
    /// Class containing settings of a tag.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class Tag : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> class.
        /// </summary>
        public Tag()
            : this(true, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> class.
        /// </summary>
        /// <param name="enabled">Wether the tag is enabled.</param>
        /// <param name="format">The format.</param>
        /// <param name="levels">The levels.</param>
        /// <param name="outputs">The outputs.</param>
        public Tag(
            bool enabled = true,
            string format = null,
            LevelContainer levels = null,
            OutputContainer outputs = null)
        {
            this.Enabled = enabled;
            this.Format = format;
            this.Levels = levels;
            this.Outputs = outputs;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Tag"/> is enabled.
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
        /// Gets or sets the level settings.
        /// </summary>
        /// <value>
        /// The levels.
        /// </value>
        public LevelContainer Levels { get; set; }

        /// <summary>
        /// Gets or sets the outputs.
        /// </summary>
        /// <value>
        /// The outputs.
        /// </value>
        public OutputContainer Outputs { get; set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Outputs?.Dispose();
        }
    }
}