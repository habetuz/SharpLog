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
            : this(null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnsiConsoleOutput"/> class.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="levels">The levels.</param>
        public AnsiConsoleOutput(
            string? format = null,
            LevelContainer? levels = null)
        {
            this.Format = format;
            this.Levels = levels;
        }

        /// <summary>
        /// Writes the specified formatted log.
        /// </summary>
        /// <param name="formattedLog">The formatted log.</param>
        /// <param name="log">The log.</param>
        public override void Write(string formattedLog, Log log)
        {
            AnsiConsole.MarkupLine(formattedLog);
        }
    }
}
