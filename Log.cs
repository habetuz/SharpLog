// <copyright file="Log.cs" company="Marvin Fuchs">
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
    using System;
    using System.Reflection;
    using SharpLog.Settings;

    /// <summary>
    /// Log structure containing all information about the log.
    /// </summary>
    public struct Log
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Log"/> struct.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="class">The class.</param>
        /// <param name="method">The method.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="levelSettings">The level settings.</param>
        /// <param name="format">The format.</param>
        /// <param name="time">The time.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public Log(LogLevel level, object message, Type @class, MethodBase method, string tag, Exception exception, Level levelSettings, string format, DateTime time, string stackTrace)
        {
            this.Level = level;
            this.Message = message;
            this.Class = @class;
            this.Function = method;
            this.Tag = tag;
            this.Exception = exception;
            this.LevelSettings = levelSettings;
            this.Format = format;
            this.Time = time;
            this.StackTrace = stackTrace;
        }

        /// <summary>
        /// Gets or sets the level of the log.
        /// </summary>
        /// <value>
        /// The level.
        /// </value>
        public LogLevel Level { get; set; }

        /// <summary>
        /// Gets or sets the sender type.
        /// </summary>
        /// <value>
        /// The class.
        /// </value>
        public Type Class { get; set; }

        /// <summary>
        /// Gets or sets the sender function.
        /// </summary>
        public MethodBase Function { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public object Message { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the format of the log.
        /// </summary>
        /// <value>
        /// The format.
        /// </value>
        public string Format { get; set; }

        /// <summary>
        /// Gets or sets the level settings.
        /// </summary>
        /// <value>
        /// The level settings.
        /// </value>
        public Level LevelSettings { get; set; }

        /// <summary>
        /// Gets or sets the time the log was logged.
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public DateTime Time { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        /// <value>
        /// The stack trace.
        /// </value>
        public string StackTrace { get; set; }
    }
}
