using SharpLog.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Outputs
{
    public abstract class IOutput
    {
        public string Format { get; set; }
        public LevelContainer Levels { get; set; }

        public IOutput() : this(null, null)
        {
        }

        public IOutput(string format, LevelContainer levels)
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

            if (Levels != null && Levels.getLevel(log.Level) != null)
            {
                Level levelSettings = Levels.getLevel(log.Level);
                
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
    }
}
