﻿// <copyright file="Logger.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
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
        /// <summary>
        /// The identification-tag of the logger.
        /// </summary>
        private string ident = "NoName";

        /// <summary>
        /// Flags that indicate what logging levels should be logged.
        /// </summary>
        private LogType logFlags = LogType.Info | LogType.Warning | LogType.Error;

        /// <summary>
        /// List with all output sources the logger should log to.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the list containing all output sources the logger should log to.
        /// </summary>
        public List<IOutput> Outputs
        {
            get
            {
                return this.outputs;
            }

            set
            {
                this.outputs = value;
            }
        }

        /// <summary>
        /// Gets or sets the flags that indicate what logging levels the logger should log.
        /// </summary>
        public LogType LogFlags
        {
            get
            {
                return this.logFlags;
            }

            set
            {
                this.logFlags = value;
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
                    this.logFlags |= LogType.Debug;
                }
                else
                {
                    this.logFlags &= ~LogType.Debug;
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
                    this.logFlags |= LogType.Info;
                }
                else
                {
                    this.logFlags &= ~LogType.Info;
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
                    this.logFlags |= LogType.Warning;
                }
                else
                {
                    this.logFlags &= ~LogType.Warning;
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
                    this.logFlags |= LogType.Error;
                }
                else
                {
                    this.logFlags &= ~LogType.Error;
                }
            }
        }

        /// <summary>
        /// Logs to the console with time, origin and type information.
        /// </summary>
        /// <param name="log">The object to be logged</param>
        /// <param name="type">The type of the log</param>
        public void Log(object log, LogType type = LogType.Debug)
        {
            if ((this.logFlags & type) != 0)
            {
                string text = string.Format(
                    "[{0}] [{1}] [{2}]: {3}",
                    DateTime.UtcNow.ToString("dd-MM-yyyy | HH:mm:ss.fff"),
                    type.ToString(),
                    this.ident,
                    log);
                this.outputs.ForEach(output =>
                {
                    output.Write(text, type);
                });
            }
        }
    }
}