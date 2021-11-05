// <copyright file="IOutput.cs">
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
    /// <summary>
    /// Interface for outputs used by logger.
    /// </summary>
    public interface IOutput
    {
        /// <summary>
        /// Gets or sets the <see cref="LogType"/>'s the output should log.
        /// </summary>
        LogType LogFlags { get; set; }

        /// <summary>
        /// Gets a value indicating whether the output should log instant or non-instant (asynchronous).
        /// </summary>
        bool Instant { get; }

        /// <summary>
        /// Writes the text to the output.
        /// </summary>
        /// <param name="text">The text to be written</param>
        /// <param name="logType">The log level of the log</param>
        void Write(string text, LogType logType);
    }
}