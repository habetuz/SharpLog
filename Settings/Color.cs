using System;

namespace SharpLog.Settings
{
    public class Color
    {
        public Color() : this(ConsoleColor.White, ConsoleColor.Black)
        {
        }

        public Color(ConsoleColor foreground = ConsoleColor.White, ConsoleColor background = ConsoleColor.Black)
        {
            Foreground = foreground;
            Background = background;
        }

        public ConsoleColor Background { get; set; }
        public ConsoleColor Foreground { get; set; }
    }
}
