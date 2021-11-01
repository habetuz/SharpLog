﻿// <copyright file="IOutput.cs">
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
        LogType LogFlags { get; set; }

        bool Instant { get; }

        /// <summary>
        /// Writes the text to the output.
        /// </summary>
        /// <param name="text">The text to be written</param>
        /// <param name="logType">The log level of the log</param>
        void Write(string text, LogType logType);
    }
}