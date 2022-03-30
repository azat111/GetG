using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azat.Task6;
namespace Azat.Task6
{
    public class LocalFileLogger<T> : ILogger
    {
        private static string file = "C:/Users/azat/Desktop/file.txt";
        private static void CreateFile(string soob)
        {
            File.AppendAllText(file, soob);
        }
        public string LogError(string message, Exception ex)
        {
            string soob = $"\n[Error] : [{typeof(T)}] : {message}. {ex.Message}\n";
            CreateFile(soob);
            return soob;
        }

        public string LogInfo(string message)
        {
            string soob = $"\n[Info]: [{typeof(T)}] : {message}\n";
            CreateFile(soob);
            return soob;
        }

        public string LogWarning(string message)
        {
            string soob = $"\n[Warning] : [{typeof(T)}] : {message}\n";
            CreateFile(soob);
            return soob;
        }
    }
}
