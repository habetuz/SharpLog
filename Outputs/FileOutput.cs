using SharpLog.Settings;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;

namespace SharpLog.Outputs
{
    public class FileOutput : Output
    {
        private readonly BlockingCollection<string> _queue = new BlockingCollection<string>();
        private Task _task;
        private CancellationTokenSource _cancellationToken;

        public FileOutput() : this(".log", 500, null, null)
        {
        }

        public FileOutput(
            string path = ".log",
            int suspendTime = 500,
            string format = null,
            LevelContainer levels = null) : base(format, levels)
        {
            Path = path;
            SuspendTime = suspendTime;
        }

        public string Path { get; set; }
        
        public int SuspendTime { get; set; }

        public override void Dispose()
        {
            _cancellationToken?.Cancel();
            _task?.Wait();
            _cancellationToken?.Dispose();
            _queue.Dispose();
            _task?.Dispose();
        }

        public override void Start()
        {
            _cancellationToken = new CancellationTokenSource();
            _task = Task.Run(() =>
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    if (_queue.Count > 0)
                    {
                        using (var writer = new StreamWriter(File.Open(Path, FileMode.Append, FileAccess.Write)))
                        {
                            while (_queue.Count > 0)
                            {
                                var line = _queue.Take();
                                writer.WriteLine(line);
                            }
                            writer.Flush();
                        }
                    }

                    Task.Delay(SuspendTime).Wait();
                }

                using (var writer = new StreamWriter(File.Open(Path, FileMode.Append, FileAccess.Write)))
                {
                    while (_queue.Count > 0)
                    {
                        var line = _queue.Take();
                        writer.WriteLine(line);
                    }
                    writer.Flush();
                }
            });
        }

        public override void Write(string formattedLog, Log log)
        {
            _queue.Add(formattedLog);
        }
    }
}
