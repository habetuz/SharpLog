// <copyright file="LogLevel.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

namespace SharpLog
{
    /// <summary>
    /// Specifies the log level.
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// Level debug
        /// </summary>
        Debug,

        /// <summary>
        /// Levl trace
        /// </summary>
        Trace,

        /// <summary>
        /// Level information
        /// </summary>
        Info,

        /// <summary>
        /// Level warning
        /// </summary>
        Warn,

        /// <summary>
        /// Level error
        /// </summary>
        Error,

        /// <summary>
        /// Level fatal
        /// </summary>
        Fatal,
    }
}
