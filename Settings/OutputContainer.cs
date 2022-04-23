using SharpLog.Outputs;
using System;
using System.Collections.Generic;

namespace SharpLog.Settings
{
    public class OutputContainer : IDisposable
    {
        private FileOutput _file;
        private List<Output> _outputs;

        public OutputContainer() : this(null, null, null)
        {
        }

        public OutputContainer(
            ConsoleOutput console = null,
            FileOutput file = null,
            List<Output> outputs = null)
        {
            Console = console ?? new ConsoleOutput();
            File = file ?? new FileOutput();
            Outputs = outputs ?? new List<Output>();
        }
        public ConsoleOutput Console { get; set; }
        public FileOutput File { 
            get => _file; 
            set 
            { 
                _file?.Dispose(); 
                _file = value;
            } 
        }
        
        public List<Output> Outputs
        {
            get => _outputs; 
            set
            {
                _outputs?.ForEach(o => o.Dispose());
                _outputs = value;
            }
        }

        public void Start()
        {
            File?.Start();
            _outputs.ForEach(o => o.Start());
        }
        public void Dispose()
        {
            File?.Dispose();
            Outputs?.ForEach(o => o.Dispose());
        }
    }
}