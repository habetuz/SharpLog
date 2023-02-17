// <copyright file="AsyncOutput.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using SharpLog.Settings;

namespace SharpLog.Outputs
{
    /// <summary>
    /// Base class for async outputs.
    /// </summary>
    public abstract class AsyncOutput : Output, IDisposable
    {
        private BlockingCollection<(string, Log)> queue = new();
        private Task? task;
        private CancellationTokenSource? cancellationToken;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncOutput"/> class.
        /// </summary>
        /// <param name="suspendTime">The time the output waits until it checks for new logs in ms.</param>
        /// <param name="format">The format of the output.</param>
        /// <param name="levels">The level settings of the output.</param>
        protected AsyncOutput(
            int suspendTime = 500,
            string? format = null,
            LevelContainer? levels = null)
            : base(format, levels)
        {
            this.SuspendTime = suspendTime;
        }

        /// <summary>
        /// Event called when the output gets started.
        /// </summary>
        protected event EventHandler? OnStart;

        /// <summary>
        /// Event called when the output gets disposed.
        /// </summary>
        protected event EventHandler? OnDispose;

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
            GC.SuppressFinalize(this);
            this.cancellationToken?.Cancel();
            this.task?.Wait();
            this.cancellationToken?.Dispose();
            this.queue.Dispose();
            this.task?.Dispose();

            this.OnDispose?.Invoke(this, null!);
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            this.OnStart?.Invoke(this, null!);

            this.cancellationToken = new CancellationTokenSource();
            this.task = Task.Run(() =>
            {
                while (!this.cancellationToken.IsCancellationRequested)
                {
                    if (this.queue.Count > 0)
                    {
                        var logs = this.queue.ToArray();
                        this.queue.Dispose();
                        this.queue = new BlockingCollection<(string, Log)>();
                        while (this.WriteNonBlocking(logs) && !this.cancellationToken.IsCancellationRequested)
                        {
                            Task.Delay(this.SuspendTime).Wait();
                        }
                    }

                    Task.Delay(this.SuspendTime).Wait();
                }

                if (this.queue.Count == 0)
                {
                    return;
                }

                this.WriteNonBlocking(this.queue.ToArray());
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
        /// <returns><c>true</c> if the write was not successful but should be tried again.</returns>
        public abstract bool WriteNonBlocking((string, Log)[] logs);
    }
}
