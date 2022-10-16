// <copyright file="OutputContainer.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

namespace SharpLog.Settings
{
    using System;
    using System.Collections.Generic;
    using SharpLog.Outputs;

    /// <summary>
    /// Container for the output settings.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public class OutputContainer : IDisposable
    {
        private readonly List<Output> outputs;
        private FileOutput file;
        private EmailOutput email;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputContainer"/> class.
        /// </summary>
        public OutputContainer()
            : this(null, null, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutputContainer"/> class.
        /// </summary>
        /// <param name="console">The console output.</param>
        /// <param name="file">The file output.</param>
        /// <param name="outputs">The output list.</param>
        public OutputContainer(
            ConsoleOutput console = null,
            FileOutput file = null,
            List<Output> outputs = null)
        {
            this.Console = console ?? new ConsoleOutput();
            this.File = file;
            this.outputs = outputs ?? new List<Output>();
        }

        /// <summary>
        /// Gets or sets the console output.
        /// </summary>
        /// <value>
        /// The console output.
        /// </value>
        public ConsoleOutput Console { get; set; }

        /// <summary>
        /// Gets or sets the file output.
        /// </summary>
        /// <value>
        /// The file output.
        /// </value>
        public FileOutput File
        {
            get => this.file;
            set
            {
                this.file?.Dispose();
                this.file = value;
                value?.Start();
            }
        }

        public EmailOutput Email
        {
            get => this.email;
            set
            {
                this.email?.Dispose();
                this.email = value;
                value?.Start();
            }
        }

        /// <summary>
        /// Adds an output and starts it if needed.
        /// </summary>
        /// <param name="output">The output.</param>
        public void AddOutput(Output output)
        {
            this.outputs.Add(output);

            if (output is AsyncOutput asyncOutput)
            {
                asyncOutput.Start();
            }
        }

        /// <summary>
        /// Removes and disposes an output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void RemoveOutput(Output output)
        {
            this.outputs.Remove(output);

            if (output is AsyncOutput asyncOutput)
            {
                asyncOutput.Dispose();
            }
        }

        /// <summary>
        /// Get the list with outputs.
        /// </summary>
        /// <returns>Array containing the outputs.</returns>
        public Output[] GetOutputs()
        {
            return this.outputs.ToArray();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.File?.Dispose();
            this.Email?.Dispose();
            this.outputs.ForEach(o =>
            {
                if (o is AsyncOutput asyncOutput)
                {
                    asyncOutput.Dispose();
                }
            });
        }
    }
}