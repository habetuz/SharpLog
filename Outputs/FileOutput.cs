using SharpLog.Settings;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Outputs
{
    public class FileOutput : IOutput
    {
        public FileOutput() : this(".log", null, null)
        {
        }

        public FileOutput(
            string path = ".log",
            string format = null,
            LevelContainer levels = null) : base(format, levels)
        {
            Path = path;
        }

        public string Path { get; set; }

        public override void Write(string formattedLog, Log log)
        {
            _ = WriteToFile(formattedLog);
        }

        private async Task WriteToFile(string log)
        {
            if (!File.Exists(Path))
                File.Create(Path).Dispose();

            using (var file = File.Open(Path, FileMode.Append, FileAccess.Write))
            using (var writer = new StreamWriter(file))
            {
                writer.WriteLine(log);
                writer.Flush();
            }
        }
    }
}
