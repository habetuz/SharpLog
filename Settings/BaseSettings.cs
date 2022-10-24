// <copyright file="BaseSettings.cs" company="Marvin Fuchs">
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
    using System.Collections.Generic;

    /// <summary>
    /// Base class containing all settings.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class BaseSettings : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSettings"/> class.
        /// </summary>
        public BaseSettings()
            : this(
            fomat: "$D$: $Lp{[}s{]}r{7, }$$Tp{[}s{]}$[$C$->$F$] $M$$Ep{\n}i{   }$$Sp{\n}$",
            levels: null,
            outputs: null,
            tags: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSettings"/> class using default settings if not provided.
        /// </summary>
        /// <param name="fomat">The fomat.</param>
        /// <param name="levels">The levels.</param>
        /// <param name="outputs">The outputs.</param>
        /// <param name="tags">The tags.</param>
        public BaseSettings(
            string fomat = "$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\nException: }$$Sp{\nStackTrace: }$",
            LevelContainer levels = null,
            OutputContainer outputs = null,
            Dictionary<string, Tag> tags = null)
        {
            this.Format = fomat;
            this.Levels = levels ?? new LevelContainer(
                debug: new Level('?'),
                trace: new Level('&'),
                info: new Level('+'),
                warn: new Level('!'),
                error: new Level('x'),
                fatal: new Level('X'));
            this.Outputs = outputs ?? new OutputContainer();
            this.Tags = tags ?? new Dictionary<string, Tag>();

            this.Tags["SHARPLOG_INTERNAL"] = new Tag()
            {
                Outputs = new OutputContainer()
                {
                    Console = new Outputs.ConsoleOutput(),
                },
            };
        }

        /// <summary>
        /// Gets or sets the general format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the general levels.
        /// </summary>
        /// <value>
        /// The levels.
        /// </value>
        public LevelContainer Levels { get; set; }

        /// <summary>
        /// Gets or sets the general outputs.
        /// </summary>
        /// <value>
        /// The outputs.
        /// </value>
        public OutputContainer Outputs { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public Dictionary<string, Tag> Tags { get; set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Outputs?.Dispose();
            if (this.Tags != null)
            {
                foreach (var tag in this.Tags.Values)
                {
                    tag.Dispose();
                }
            }
        }
    }
}
