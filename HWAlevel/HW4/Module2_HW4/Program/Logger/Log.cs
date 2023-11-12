using System.Configuration;

namespace Module2_HW4.Program.Logger
{
    public class Log
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
