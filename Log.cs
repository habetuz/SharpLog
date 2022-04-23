using SharpLog.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog
{
    public struct Log
    {
        public Log(LogLevel level, object message, Type @class, string tag, Exception exception, Level levelSettings, string format, DateTime time, string stackTrace)
        {
            Level = level;
            Message = message;
            Class = @class;
            Tag = tag;
            Exception = exception;
            LevelSettings = levelSettings;
            Format = format;
            Time = time;
            StackTrace = stackTrace;
        }

        public LogLevel Level { get; set; }
        public Type Class { get; set; }
        public object Message { get; set; }
        public string Tag { get; set; }
        public Exception Exception { get; set; }
        public string Format { get; set; }
        public Level LevelSettings { get; set; }
        public DateTime Time { get; set; }
        public string StackTrace { get; set; }
    }
}
