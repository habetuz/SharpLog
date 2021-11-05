// <copyright file="ConsoleOutput.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace SharpLog.Output
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class handling console outputs. Supports color.
    /// </summary>
    public class ConsoleOutput : IOutput
    {
        /// <summary>
        /// Dictionary containing the log levels and the color they should be printed in.
        /// </summary>
        private static readonly Dictionary<LogType, ConsoleColor> Colors = new Dictionary<LogType, ConsoleColor>()
        {
            { LogType.Debug,    ConsoleColor.DarkGray },
            { LogType.Info,     ConsoleColor.White },
            { LogType.Warning,  ConsoleColor.Yellow },
            { LogType.Error,    ConsoleColor.Red },
        };
        
        /// <summary>
        /// Gets or sets which <see cref="LogType"/>'s should be logged.
        /// </summary>
        public LogType LogFlags { get; set; } = LogType.Debug | LogType.Info | LogType.Warning | LogType.Error;

        /// <summary>
        /// Gets a value indicating whether the output should log instant or non-instant (asynchronous).
        /// </summary>
        public bool Instant { get; } = true;

        /// <summary>
        /// The write method that writes to the console.
        /// </summary>
        /// <param name="text">The text to be written</param>
        /// <param name="logType">The log level of the log</param>
        public void Write(string text, LogType logType)
        {
            if ((logType & this.LogFlags) != 0)
            {
                Console.ForegroundColor = Colors[logType];
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }
    }
}