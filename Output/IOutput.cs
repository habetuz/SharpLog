using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpLog.Output
{
    public interface IOutput
    {
        void Write(string text, LogType logType);
    }
}
