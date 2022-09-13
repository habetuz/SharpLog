// <copyright file="AsyncOutput.cs" company="Marvin Fuchs">
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
    using System.Collections.Concurrent;
    using System.Threading;
    using System.Threading.Tasks;
    using SharpLog.Settings;

    /// <summary>
    /// Base class for async outputs.
    /// </summary>
    public abstract class AsyncOutput : Output, IDisposable
    {
        private readonly BlockingCollection<(string, Log)> queue = new BlockingCollection<(string, Log)>();
        private Task task;
        private CancellationTokenSource cancellationToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncOutput"/> class.
        /// </summary>
        /// <param name="suspendTime">The time the output waits until it checks for new logs in ms.</param>
        /// <param name="format">The format of the output.</param>
        /// <param name="levels">The level settings of the output.</param>
        public AsyncOutput(
            int suspendTime = 500,
            string format = null,
            LevelContainer levels = null)
            : base(format, levels)
        {
            this.SuspendTime = suspendTime;
        }

        /// <summary>
        /// Gets or sets the time the output waits until it checks for new logs in ms.
        /// </summary>
        /// <value>
        /// The suspend time.
        /// </value>
        public int SuspendTime { get; set; }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
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
        public void Start()
        {
            this.cancellationToken = new CancellationTokenSource();
            this.task = Task.Run(() =>
            {
                while (!this.cancellationToken.IsCancellationRequested)
                {
                    if (this.queue.Count > 0)
                    {
                        this.WriteNonBlocking(this.queue.ToArray());
                    }

                    Task.Delay(this.SuspendTime).Wait();
                }

                if (this.queue.Count > 0)
                {
                    this.WriteNonBlocking(this.queue.ToArray());
                }
            });
        }

        /// <summary>
        /// Adds the log message to the log queue.
        /// </summary>
        /// <param name="formattedLog">The formatted log.</param>
        /// <param name="log">The log.</param>
        public override void Write(string formattedLog, Log log)
        {
            this.queue.Add((formattedLog, log));
        }

        /// <summary>
        /// Writes the logs to the output without blocking the calling thread.
        /// </summary>
        /// <param name="logs">The logs.</param>
        public abstract void WriteNonBlocking((string, Log)[] logs);
    }
}
