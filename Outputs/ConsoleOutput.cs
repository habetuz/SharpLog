using SharpLog.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Outputs
{
    public class ConsoleOutput : IOutput
    {
        public ConsoleOutput() : this(true, null, null, null)
        {
        }

        public ConsoleOutput(
            bool colorEnabled = true,
            string format = null,
            LevelContainer levels = null,
            Dictionary<LogLevel, Color> colors = null)
        {
            ColorEnabled = colorEnabled;
            Format = format;
            Levels = levels;
            Colors = colors ?? new Dictionary<LogLevel, Color>()
            {
                { LogLevel.Debug, new Color(foreground: ConsoleColor.DarkGray) },
                { LogLevel.Trace, new Color() },
                { LogLevel.Info, new Color(foreground: ConsoleColor.Green) },
                { LogLevel.Warn, new Color(foreground: ConsoleColor.Yellow) },
                { LogLevel.Error, new Color(foreground: ConsoleColor.Red) },
                { LogLevel.Fatal, new Color(background: ConsoleColor.Red, foreground: ConsoleColor.Black) }
            };
        }
        
        public bool ColorEnabled { get; set; }
        
        public Dictionary<LogLevel, Color> Colors { get; set; }

        public override void Write(string formattedLog, Log log)
        {
            Console.BackgroundColor = Colors.ContainsKey(log.Level) ? Colors[log.Level].Background : ConsoleColor.Black;
            Console.ForegroundColor = Colors.ContainsKey(log.Level) ? Colors[log.Level].Foreground : ConsoleColor.White;
            Console.WriteLine(formattedLog);
            Console.ResetColor();
        }
    }
}
