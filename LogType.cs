// <copyright file="LogType.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace SharpLog
{
    using System;

    /// <summary>
    /// Logging levels for <see cref="Logger"/> and <see cref="MassLogger"/>.
    /// </summary>
    [Flags]
    public enum LogType
    {
        Debug   = 1, 
        Info    = 2, 
        Warning = 4, 
        Error   = 8,
    }
}