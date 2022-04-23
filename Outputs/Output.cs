using SharpLog.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Outputs
{
    public abstract class Output : IDisposable
    {
        public string Format { get; set; }
        public LevelContainer Levels { get; set; }

        public Output() : this(null, null)
        {
        }

        public Output(string format, LevelContainer levels)
        {
            Format = format;
            Levels = levels;
        }

        public void Write(Log log)
        {
            if (Format != null)
            {
                log.Format = Format;
            }

            if (Levels != null && Levels.GetLevel(log.Level) != null)
            {
                Level levelSettings = Levels.GetLevel(log.Level);
                
                if (!levelSettings.Enabled)  return;
                
                log.LevelSettings = levelSettings;

                if (levelSettings.Format != null)
                {
                    log.Format = levelSettings.Format;
                }
            }

            Write(Formatter.Format(log), log);
        }
        
        public abstract void Write(string formattedLog, Log log);
        public abstract void Start();
        public abstract void Dispose();
    }
}
