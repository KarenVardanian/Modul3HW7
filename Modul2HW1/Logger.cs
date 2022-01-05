using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Modul2HW1.Interfaces;

namespace Modul2HW1
{
    public class Logger : ILogger
    {
        private static readonly Logger _instance = new Logger();
        private readonly StringBuilder _logs;
        private string _dateAndTime = " '' " + DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString() + " '' ";
        #pragma warning disable SA1202 // Elements should be ordered by access
#pragma warning disable SA1401 // Fields should be private
        public Action LooggerHandler;
#pragma warning restore SA1401 // Fields should be private
#pragma warning restore SA1202 // Elements should be ordered by access
#pragma warning disable SA1201 // Elements should appear in the correct order
        public event Action<string> TimeHandler;

        static Logger()
#pragma warning restore SA1201 // Elements should appear in the correct order
        {
        }

        private Logger()
        {
            _logs = new StringBuilder();
        }

        public static Logger Instance => _instance;
        public string AllLogs => _logs.ToString();

        public void LogInfo(string message)
        {
            Log(LogType.Info, message);
        }

        public void LogError(string message)
        {
            Log(LogType.Error, message);
        }

        public void LogWarning(string message)
        {
            Log(LogType.Warning, message);
        }

        public void Log(LogType type, string message)
        {
            var log = $"{DateTime.UtcNow}: {type.ToString()}: {message}";
            _logs.AppendLine(log);
            Console.WriteLine(log);
        }

        public void WriteToFile(string sPath)
        {
            string p = System.IO.Directory.GetCurrentDirectory();
            using (StreamWriter sw = new StreamWriter(sPath, true, System.Text.Encoding.Default))
            {
                sw.Write(_logs);
                sw.Close();
            }

            TimeHandler?.Invoke($"Time to back up");
        }
    }
}
