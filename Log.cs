﻿// <copyright file="Log.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System.Reflection;
using SharpLog.Settings;

namespace SharpLog
{
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
        /// <param name="short">The short form of the log level.</param>
        /// <param name="format">The format.</param>
        /// <param name="time">The time.</param>
        /// <param name="stackTrace">The stack trace.</param>
        public Log(
            in LogLevel level,
            in object message,
            in Type @class,
            in MethodBase method,
            in string tag,
            in Exception exception,
            in char @short,
            in string format,
            in DateTime time,
            in string stackTrace)
        {
            this.Level = level;
            this.Message = message;
            this.Class = @class;
            this.Function = method;
            this.Tag = tag;
            this.Exception = exception;
            this.Short = @short;
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
        /// Gets or sets the short form of the log level.
        /// </summary>
        /// <value>
        /// The short form of the log level.
        /// </value>
        public char Short { get; set; }

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
