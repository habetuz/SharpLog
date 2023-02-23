// <copyright file="ConsoleOutput.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using SharpLog.Settings;
using Spectre.Console;

namespace SharpLog.Outputs
{
    /// <summary>
    /// Output using <see cref="AnsiConsole"/>.
    /// </summary>
    /// <seealso cref="Output" />
    public class AnsiConsoleOutput : Output
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AnsiConsoleOutput"/> class.
        /// </summary>
        public AnsiConsoleOutput()
            : this(false, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnsiConsoleOutput"/> class.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="levels">The levels.</param>
        public AnsiConsoleOutput(
            bool ansiErrorPrint = false,
            string? format = null,
            LevelContainer? levels = null)
        {
            this.AnsiErrorPrint = ansiErrorPrint;
            this.Format = format;
            this.Levels = levels;
        }

        /// <summary>
        /// Gets or sets a value indicating wether the build in error logging capability of <see cref="Spectre.Console.AnsiConsole"/> should be used.
        /// Do not specify an error format if you set this parameter to true, else the error will be logged twice.
        /// </summary>
        public bool AnsiErrorPrint { get; set; }

        /// <summary>
        /// Writes the specified formatted log.
        /// </summary>
        /// <param name="formattedLog">The formatted log.</param>
        /// <param name="log">The log.</param>
        public override void Write(string formattedLog, Log log)
        {
            try
            {
                AnsiConsole.MarkupLine(formattedLog);

                if (this.AnsiErrorPrint && log.Exception is not null)
                {
                    AnsiConsole.WriteException(log.Exception, ExceptionFormats.ShortenEverything);
                }
            }
            catch (InvalidOperationException e)
            {
                AnsiConsole.MarkupLine("[yellow]The following message contains invalid markup:[/]");
                AnsiConsole.WriteLine(formattedLog);
                AnsiConsole.WriteException(e, ExceptionFormats.ShortenEverything);
            }
        }
    }
}
