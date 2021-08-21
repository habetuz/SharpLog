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
        private readonly string fileName;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOutput"/> class.
        /// </summary>
        /// <param name="fileName">The name or path to the file the output should write to</param>
        public FileOutput(string fileName)
        {
            this.fileName = fileName;
        }

        /// <summary>
        /// The write method that writes to the <see cref="fileName"/>.
        /// </summary>
        /// <param name="text">The text to be written</param>
        /// <param name="logType">The log level of the log</param>
        public void Write(string text, LogType logType)
        {
            new Thread(this.AsyncWrite).Start(text);
        }

        /// <summary>
        /// The write method that gets executed asynchronous in the <see cref="Write(string, LogType)"/> method.
        /// </summary>
        /// <param name="text">The text to be written</param>
        private void AsyncWrite(object text)
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