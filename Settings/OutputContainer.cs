// <copyright file="OutputContainer.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
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
        private FileOutput file;
        private List<Output> outputs;

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
        /// <param name="outputs">The outputs list.</param>
        public OutputContainer(
            ConsoleOutput console = null,
            FileOutput file = null,
            List<Output> outputs = null)
        {
            this.Console = console ?? new ConsoleOutput();
            this.File = file ?? new FileOutput();
            this.Outputs = outputs ?? new List<Output>();
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
            }
        }

        /// <summary>
        /// Gets or sets the list with outputs.
        /// </summary>
        /// <value>
        /// The outputs.
        /// </value>
        public List<Output> Outputs
        {
            get => this.outputs;
            set
            {
                this.outputs?.ForEach(o => o.Dispose());
                this.outputs = value;
            }
        }

        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start()
        {
            this.File?.Start();
            this.Outputs.ForEach(o => o.Start());
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.File?.Dispose();
            this.Outputs?.ForEach(o => o.Dispose());
        }
    }
}