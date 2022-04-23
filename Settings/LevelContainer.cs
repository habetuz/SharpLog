namespace SharpLog.Settings
{
    public class LevelContainer
    {
        public LevelContainer() : this(null, null, null, null, null, null)
        {
        }

        public LevelContainer(
            Level debug = null,
            Level trace = null,
            Level info = null,
            Level warn = null,
            Level error = null,
            Level fatal = null)
        {
            Debug = debug;
            Trace = trace;
            Info = info;
            Warn = warn;
            Error = error;
            Fatal = fatal;
        }
        
        public Level Debug { get; set; }
        public Level Trace { get; set; }
        public Level Info { get; set; }
        public Level Warn { get; set; }
        public Level Error { get; set; }
        public Level Fatal { get; set; }
        
        public Level GetLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return Debug;
                case LogLevel.Trace:
                    return Trace;
                case LogLevel.Info:
                    return Info;
                case LogLevel.Warn:
                    return Warn;
                case LogLevel.Error:
                    return Error;
                case LogLevel.Fatal:
                    return Fatal;
                default:
                    return null;
            }
        }
    }
}