﻿// <copyright file="FileOutput.cs">
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
    using System.IO;
    using System.Threading;

    /// <summary>
    /// Class handling file outputs.
    /// </summary>
    public class FileOutput : IOutput
    {
        /// <summary>
        /// The logger of file outputs.
        /// </summary>
        private static readonly Logger Logger = new Logger()
        {
            Ident = "SharpLog/FileOutput"
        };

        /// <summary>
        /// The name or path to the file the output should write to.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOutput"/> class.
        /// </summary>
        /// <param name="fileName">The name or path of the file the output should write to</param>
        public FileOutput(string fileName = ".log")
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// Sets the name or path of the file the output should write to.
        /// </summary>
        public string FileName 
        { 
            set 
            { 
                this.fileName = value; 
            } 
        }

        /// <summary>
        /// Gets or sets the <see cref="LogType"/>'s the output should log.
        /// </summary>
        public LogType LogFlags { get; set; } = LogType.Debug | LogType.Info | LogType.Warning | LogType.Error;

        /// <summary>
        /// Gets a value indicating whether the output should log instant or non-instant (asynchronous).
        /// </summary>
        public bool Instant { get; } = false;

        /// <summary>
        /// The write method that writes to the <see cref="FileName"/>.
        /// </summary>
        /// <param name="text">The text to be written</param>
        /// <param name="logType">The log level of the log</param>
        public void Write(string text, LogType logType)
        {
            if ((this.LogFlags & logType) != 0)
            {
                bool successfull;
                do
                {
                    successfull = true;

                    try
                    {
                        using (StreamWriter writer = File.AppendText(this.fileName))
                        {
                            writer.WriteLine(text);
                        }
                    }
                    catch (IOException)
                    {
                        Logger.Log("Writing to " + this.fileName + " failed. Trying again...", LogType.Warning);
                        Thread.Sleep(1000);
                        successfull = false;
                    }
                }
                while (!successfull);
            }
        }
    }
}