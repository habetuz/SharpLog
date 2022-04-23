// <copyright file="FileOutput.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace SharpLog.Outputs
{
    using System.Collections.Concurrent;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using SharpLog.Settings;

    /// <summary>
    /// Output writing asynchronously to a file.
    /// </summary>
    /// <seealso cref="SharpLog.Outputs.Output" />
    public class FileOutput : Output
    {
        private readonly BlockingCollection<string> queue = new BlockingCollection<string>();
        private Task task;
        private CancellationTokenSource cancellationToken;

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
        /// <param name="suspendTime">The suspend time.</param>
        /// <param name="format">The format.</param>
        /// <param name="levels">The levels.</param>
        public FileOutput(
            string path = ".log",
            int suspendTime = 500,
            string format = null,
            LevelContainer levels = null)
            : base(format, levels)
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

        /// <summary>
        /// Gets or sets the time the output waits until it checks for new logs again.
        /// </summary>
        /// <value>
        /// The suspend time.
        /// </value>
        public int SuspendTime { get; set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public override void Dispose()
        {
            this.cancellationToken?.Cancel();
            this.task?.Wait();
            this.cancellationToken?.Dispose();
            this.queue.Dispose();
            this.task?.Dispose();
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public override void Start()
        {
            this.cancellationToken = new CancellationTokenSource();
            this.task = Task.Run(() =>
            {
                while (!this.cancellationToken.IsCancellationRequested)
                {
                    if (this.queue.Count > 0)
                    {
                        using (var writer = new StreamWriter(File.Open(this.Path, FileMode.Append, FileAccess.Write)))
                        {
                            while (this.queue.Count > 0)
                            {
                                var line = this.queue.Take();
                                writer.WriteLine(line);
                            }

                            writer.Flush();
                        }
                    }

                    Task.Delay(this.SuspendTime).Wait();
                }

                using (var writer = new StreamWriter(File.Open(this.Path, FileMode.Append, FileAccess.Write)))
                {
                    while (this.queue.Count > 0)
                    {
                        var line = this.queue.Take();
                        writer.WriteLine(line);
                    }

                    writer.Flush();
                }
            });
        }

        /// <summary>
        /// Writes the specified formatted log.
        /// </summary>
        /// <param name="formattedLog">The formatted log.</param>
        /// <param name="log">The log.</param>
        public override void Write(string formattedLog, Log log)
        {
            this.queue.Add(formattedLog);
        }
    }
}
