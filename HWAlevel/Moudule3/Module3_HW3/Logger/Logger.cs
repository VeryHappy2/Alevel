using System.Configuration;
using System.IO;

namespace Module3_HW3.Logger
{
    public class Logger
    {
        public static void WriteLogger(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{message}");
            }
        }
    }
}
