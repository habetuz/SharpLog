// <copyright file="BaseSettings.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System;
using System.Collections.Generic;
using SharpLog.Outputs;

namespace SharpLog.Settings
{
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
                format: "[$D$] - $La{u}r{7, }$$Tp{ - }r{10, }$ - $Cs{ -}r{30,-}$> $Fr{20, }$ - $M$$Ep{\n}i{   }$$Sp{\n}$",
                levels: null,
                outputs: null,
                tags: null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseSettings"/> class using default settings if not provided.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="levels">The levels.</param>
        /// <param name="outputs">The outputs.</param>
        /// <param name="tags">The tags.</param>
        public BaseSettings(
            string format = "$D$: [$L$]$Cp{ [}s{] }$$Tp{ [}s{] }$ $M$$Ep{\nException: }$$Sp{\nStackTrace: }$",
            LevelContainer? levels = null,
            OutputContainer? outputs = null,
            Dictionary<string, Tag>? tags = null)
        {
            this.Format = format;
            this.Levels = levels
                ?? new LevelContainer(
                    debug: new Level('?'),
                    trace: new Level('&'),
                    info: new Level('+'),
                    warning: new Level('!'),
                    error: new Level('x'),
                    fatal: new Level('X'));
            this.Outputs = outputs
                ?? new OutputContainer()
                    {
                        new Outputs.ConsoleOutput(),
                        new Outputs.FileOutput(),
                    };
            this.Tags = tags ?? new Dictionary<string, Tag>();

            this.Tags["SHARPLOG_INTERNAL"] = new Tag()
            {
                Levels = new LevelContainer
                {
                    Debug = new Level
                    {
                        Enabled = false,
                    },
                    Trace = new Level
                    {
                        Enabled = false,
                    },
                    Info = new Level
                    {
                        Enabled = false,
                    },
                },
                Outputs = new OutputContainer
                {
                    new AnsiConsoleOutput
                    {
                        AnsiErrorPrint = true,
                        Levels = new LevelContainer(
                            debug: new Level('?', format: "[bold gray]$La{s}p{[[}s{]]}$[/] - $M$$Sp{\nStackTrace: }$"),
                            trace: new Level('&', format: "[bold white]$La{s}p{[[}s{]]}$[/] - $M$$Sp{\nStackTrace: }$"),
                            info: new Level('+', format: "[bold green]$La{s}p{[[}s{]]}$[/] - $M$$Sp{\nStackTrace: }$"),
                            warning: new Level('!', format: "[bold yellow]$La{s}p{[[}s{]]}$[/] - $M$$Sp{\nStackTrace: }$"),
                            error: new Level('x', format: "[bold red]$La{s}p{[[}s{]]}$[/] - $M$$Sp{\nStackTrace: }$"),
                            fatal: new Level('X', format: "[bold white on red]$La{s}p{[[}s{]]}$[/] - $M$$Sp{\nStackTrace: }$"))
                    },
                },
            };
        }

        /// <summary>
        /// Gets or sets the general format.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public string? Format { get; set; }

        /// <summary>
        /// Gets or sets the general levels.
        /// </summary>
        /// <value>
        /// The levels.
        /// </value>
        public LevelContainer? Levels { get; set; }

        /// <summary>
        /// Gets or sets the general outputs.
        /// </summary>
        /// <value>
        /// The outputs.
        /// </value>
        public OutputContainer? Outputs { get; set; }

        /// <summary>
        /// Gets or sets the tags.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        public Dictionary<string, Tag>? Tags { get; set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Logging.LogInfo("Disposing SharpLog!", "SHARPLOG_INTERNAL");

            this.Outputs?.Dispose();
            if (this.Tags == null)
            {
                return;
            }

            foreach (var tag in this.Tags.Values)
            {
                tag.Dispose();
            }
        }
    }
}
