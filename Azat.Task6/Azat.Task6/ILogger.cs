using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azat.Task6;
namespace Azat.Task6
{
    public interface ILogger
    {
        public string LogInfo(string message);
        public string LogWarning(string message);
        public string LogError(string message, Exception ex);
    }
}
