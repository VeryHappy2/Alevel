using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module2_HW.MainLogic
{
    public sealed class FileService
    {
        private object _lock = new object();
        public string LogDirectory = "Logs";
        public async void WriteToFile(string logEntry, string fileFormat)
        {
            if (!Directory.Exists(LogDirectory))
            {
                Directory.CreateDirectory(LogDirectory);
            }

            string logTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt");

            string fileName = $"{DateTime.Now:MM_dd_yyyy_hh_mm_ss_fff_tt}.{fileFormat}";
            string filePath = Path.Combine(LogDirectory, fileName);

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(logEntry);
            }

            string[] files = Directory.GetFiles(LogDirectory);
            if (files.Length > 3)
            {
                Array.Sort(files, StringComparer.InvariantCulture);
                File.Delete(files[0]);
                Console.WriteLine("File was deleted");
            }

        }
    }
}
