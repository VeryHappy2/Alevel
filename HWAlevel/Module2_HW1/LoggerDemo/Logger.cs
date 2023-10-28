using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDemo
{
    internal class Logger
    {
        readonly public string logPath = ConfigurationManager.AppSettings["logPath"];

        public  void LogWarning(string message)
        {
            using (StreamWriter writerWarning = new StreamWriter(logPath, true))
            {
                writerWarning.WriteLine($"{DateTime.Now} : [Warning] {message}");
            }

        }

        public  void LogError(string message)
        {
            using (StreamWriter writerError = new StreamWriter(logPath, true))
            {
                writerError.WriteLine($"{DateTime.Now} : [Error] {message}");
            }
        }

        public  void LogInfo(string message)
        {
            using (StreamWriter writerInfo = new StreamWriter(logPath, true))
            {
             writerInfo.WriteLine($"{DateTime.Now} : Info");
            }
        }

        //public static void WriteLogger(string message)
        //{
        //string logPath = ConfigurationManager.AppSettings["logPath"];

        //using (StreamWriter writer = new StreamWriter(logPath, true))
        //{
        // writer.WriteLine($"{DateTime.Now} : {message}");
        //}
    }
}
