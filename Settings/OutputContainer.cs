using SharpLog.Outputs;
using System.Collections.Generic;

namespace SharpLog.Settings
{
    public class OutputContainer
    {
        public OutputContainer() : this(null, null, null)
        {
        }

        public OutputContainer (
            ConsoleOutput console = null,
            FileOutput file = null,
            List<IOutput> outputs = null)
        {
            Console = console ?? new ConsoleOutput();
            File = file ?? new FileOutput();
            Outputs = outputs ?? new List<IOutput>();
        }
        public ConsoleOutput Console { get; set; }
        public FileOutput File { get; set; }
        public List<IOutput> Outputs { get; set; }
    }
}