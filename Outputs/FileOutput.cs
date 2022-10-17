// <copyright file="FileOutput.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

namespace SharpLog.Outputs
{
    using System;
    using System.IO;
    using SharpLog.Settings;

    /// <summary>
    /// Output writing asynchronously to a file.
    /// </summary>
    /// <seealso cref="SharpLog.Outputs.AsyncOutput" />
    public class FileOutput : AsyncOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileOutput"/> class.
        /// </summary>
        public FileOutput()
            : this(".log", 500, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileOutput"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="suspendTime">The suspend time between logs in ms.</param>
        /// <param name="format">The format.</param>
        /// <param name="levels">The level settings.</param>
        public FileOutput(
            string path = ".log",
            int suspendTime = 500,
            string format = null,
            LevelContainer levels = null)
            : base(suspendTime, format, levels)
        {
            this.Path = path;
            this.SuspendTime = suspendTime;
        }

        /// <summary>
        /// Gets or sets the path the output should log to.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path { get; set; }

        /// <inheritdoc/>
        public override bool WriteNonBlocking((string, Log)[] logs)
        {
            try
            {
                using (var writer = new StreamWriter(File.Open(this.Path, FileMode.Append, FileAccess.Write)))
                {
                    foreach (var log in logs)
                    {
                        writer.WriteLine(log.Item1);
                    }

                    writer.Flush();
                }
            }
            catch (IOException)
            {
                return true;
            }
            catch (Exception e)
            {
                Logging.LogError("An error occurred while logging to a file.", "SHARPLOG_INTERNAL", e);
            }

            return false;
        }
    }
}
