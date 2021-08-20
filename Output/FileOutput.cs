using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Output
{
    using System.IO;
    using System.Threading;

    public class FileOutput : IOutput
    {
        private static readonly Logger logger = new Logger()
        {
            Ident = "SharpLog/FileOutput"
        };

        private readonly string fileName;

        public FileOutput(string fileName)
        {
            this.fileName = fileName;
        }

        public void Write(string text, LogType logType)
        {
            new Thread(asyncWrite).Start(text);
        }

        private void asyncWrite(object text)
        {
            bool successfull;
            do
            {
                successfull = true;

                try
                {
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(text);
                    }
                }
                catch (IOException)
                {
                    logger.Log("Writing to " + fileName + " failed. Trying again...", LogType.Warning);
                    Thread.Sleep(1000);
                    successfull = false;
                }
            } while (!successfull);
        }
    }
}
