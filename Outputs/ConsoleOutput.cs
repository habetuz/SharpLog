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
using SharpLog.Settings.Wrapper;

namespace SharpLog.Outputs
{
    /// <summary>
    /// Output using <see cref="Console"/>.
    /// </summary>
    /// <seealso cref="Output" />
    public class ConsoleOutput : Output
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutput"/> class.
        /// </summary>
        public ConsoleOutput()
            : this(true, null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleOutput"/> class.
        /// </summary>
        /// <param name="colorEnabled">If set to <c>true</c> color output is enabled.</param>
        /// <param name="format">The format.</param>
        /// <param name="levels">The levels.</param>
        /// <param name="colors">The colors.</param>
        public ConsoleOutput(
            bool colorEnabled = true,
            string? format = null,
            LevelContainer? levels = null,
            Dictionary<LogLevel, Color>? colors = null)
        {
            this.ColorEnabled = colorEnabled;
            this.Format = format;
            this.Levels = levels;
            this.Colors = colors
                ?? new Dictionary<LogLevel, Color>()
                    {
                        { LogLevel.Debug, new Color(foreground: ConsoleColor.DarkGray) },
                        { LogLevel.Trace, new Color() },
                        { LogLevel.Info, new Color(foreground: ConsoleColor.Green) },
                        { LogLevel.Warning, new Color(foreground: ConsoleColor.Yellow) },
                        { LogLevel.Error, new Color(foreground: ConsoleColor.Red) },
                        { LogLevel.Fatal, new Color(foreground: ConsoleColor.Black, background: ConsoleColor.Red) },
                    };
        }

        /// <summary>
        /// Gets or sets a value indicating whether color is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if color is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool ColorEnabled { get; set; }

        /// <summary>
        /// Gets or sets the colors for each log level.
        /// </summary>
        /// <value>
        /// The colors.
        /// </value>
        public Dictionary<LogLevel, Color> Colors { get; set; }

        /// <summary>
        /// Writes the specified formatted log.
        /// </summary>
        /// <param name="formattedLog">The formatted log.</param>
        /// <param name="log">The log.</param>
        public override void Write(string formattedLog, Log log)
        {
            if (this.ColorEnabled)
            {
                Console.BackgroundColor = Colors.TryGetValue(log.Level, out Color? value) ? value.Background : ConsoleColor.Black;
                Console.ForegroundColor = Colors.TryGetValue(log.Level, out value) ? value.Foreground : ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }

            Console.WriteLine(formattedLog);
            Console.ResetColor();
        }
    }
}
