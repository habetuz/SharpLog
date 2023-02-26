// <copyright file="Color.cs" company="Marvin Fuchs">
// Copyright (c) Marvin Fuchs. All rights reserved.
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information.
// </summary>

using System;

namespace SharpLog.Settings.Wrapper
{
    /// <summary>
    /// Class containing colors for the <see cref="SharpLog.Outputs.ConsoleOutput"/>.
    /// </summary>
    public class Color
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class.
        /// </summary>
        public Color()
            : this(ConsoleColor.White, ConsoleColor.Black)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> class.
        /// </summary>
        /// <param name="foreground">The foreground color.</param>
        /// <param name="background">The background color.</param>
        public Color(
            ConsoleColor foreground = ConsoleColor.White,
            ConsoleColor background = ConsoleColor.Black)
        {
            this.Foreground = foreground;
            this.Background = background;
        }

        /// <summary>
        /// Gets or sets the background color.
        /// </summary>
        /// <value>
        /// The background color.
        /// </value>
        public ConsoleColor Background { get; set; }

        /// <summary>
        /// Gets or sets the foreground color.
        /// </summary>
        /// <value>
        /// The foreground color.
        /// </value>
        public ConsoleColor Foreground { get; set; }
    }
}
