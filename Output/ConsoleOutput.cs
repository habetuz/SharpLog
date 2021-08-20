using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Output
{
    using System.Collections.Generic;

    public class ConsoleOutput : IOutput
    {
        private static readonly Dictionary<LogType, ConsoleColor> Colors = new Dictionary<LogType, ConsoleColor>()
        {
            { LogType.Debug,    ConsoleColor.DarkGray  },
            { LogType.Info,     ConsoleColor.White },
            { LogType.Warning,  ConsoleColor.Yellow },
            { LogType.Error,    ConsoleColor.Red },
        };
        public void Write(string text, LogType logType)
        {
            Console.ForegroundColor = Colors[logType];
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
