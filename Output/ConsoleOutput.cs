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

        private LogType logFlags = LogType.Debug | LogType.Info | LogType.Warning | LogType.Error;

        public LogType LogFlags { get
            {
                return this.logFlags;
            }
            set
            {
                this.logFlags = value;
            }
        }

        /// <summary>
        /// The write method that writes to the console.
        /// </summary>
        /// <param name="text">The text to be written</param>
        /// <param name="logType">The log level of the log</param>
        public void Write(string text, LogType logType)
        {
            if((logType & this.logFlags) != 0)
            {
                Console.ForegroundColor = Colors[logType];
                Console.WriteLine(text);
                Console.ResetColor();
            }
        }
    }
}