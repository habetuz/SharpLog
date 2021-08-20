// <copyright file="Logger.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace SharpLog
{
    using System;
    using System.Collections.Generic;
    using SharpLog.Output;

    /// <summary>
    /// Class for uniformly and clear logging over the whole project.
    /// </summary>
    public class Logger
    {
        private string ident = "NoName";
        private LogType logFlags = LogType.Info | LogType.Warning | LogType.Error;
        private List<IOutput> outputs = new List<IOutput>() { new ConsoleOutput() };

        /// <summary>
        /// Sets the identification-tag of the logger.
        /// </summary>
        public string Ident
        {
            set
            {
                this.ident = value;
            }
        }

        public List<IOutput> Outputs
        {
            set
            {
                this.outputs = value;
            }

            get
            {
                return this.outputs;
            }
        }

        public LogType LogFlags
        {
            set
            {
                this.logFlags = value;
            }

            get
            {
                return this.logFlags;
            }
        }

        /// <summary>
        /// Sets a value indicating whether <see cref="LogType.Debug"/> should be logged.
        /// </summary>
        public bool LogDebug
        {
            set
            {
                if (value)
                {
                    logFlags |= LogType.Debug;
                }
                else
                {
                    logFlags &= ~LogType.Debug;
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether <see cref="LogType.Info"/> should be logged.
        /// </summary>
        public bool LogInfo
        {
            set
            {
                if (value)
                {
                    logFlags |= LogType.Info;
                }
                else
                {
                    logFlags &= ~LogType.Info;
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether <see cref="LogType.Warning"/> should be logged.
        /// </summary>
        public bool LogWarning
        {
            set
            {
                if (value)
                {
                    logFlags |= LogType.Warning;
                }
                else
                {
                    logFlags &= ~LogType.Warning;
                }
            }
        }

        /// <summary>
        /// Sets a value indicating whether <see cref="LogType.Error"/> should be logged.
        /// </summary>
        public bool LogError
        {
            set
            {
                if (value)
                {
                    logFlags |= LogType.Error;
                }
                else
                {
                    logFlags &= ~LogType.Error;
                }
            }
        }

        /// <summary>
        /// Logs to the console with time, origin and type information.
        /// </summary>
        /// <param name="text">The log to be logged</param>
        /// <param name="type">The type of the log</param>
        public void Log(object log, LogType type = LogType.Debug)
        {
            if ((this.logFlags & type) != 0)
            {
                string text = string.Format("[{0}] [{1}] [{2}]: {3}",
                    DateTime.UtcNow.ToString("dd-MM-yyyy | HH:mm:ss.fff"),
                    type.ToString(),
                    this.ident,
                    log);
                outputs.ForEach(output =>
                {
                    output.Write(text, type);
                });
            }
        }
    }
}