using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Text;

namespace HW6
{
    public class Logger
    {
        private ConcurrentBag<int> _linesOfTextFile = new ConcurrentBag<int> { 0 };
        public delegate Task Delegate();
        public event Delegate BackupRequired;

        private async Task Writer(string way, string message)
        {
            using (StreamWriter writer = new StreamWriter(way, true, Encoding.UTF8))
            {
                await writer.WriteAsync(message);
            }
        }
        public async Task WriteLog()
        {
            App app = new App();
            InteractionJson interactionJson = new InteractionJson();

            BackupRequired += app.CreateBackUpFile;

            await interactionJson.ReadJson();
            int limit = interactionJson.N.Backup;


            for (int i = 0; i < 50;)
            {
                if (_linesOfTextFile.Count <= limit)
                {
                    await Writer("TextFile.txt", "Error");
                    _linesOfTextFile.Add(i);
                    i++;
                }
                if (_linesOfTextFile.Count >= limit)
                {
                    
                    if (_linesOfTextFile.Count % limit == 0)
                    {
                        await BackupRequired?.Invoke();
                    }
                    i++;
                    await Writer(app.pathToTxt, "Error");
                    _linesOfTextFile.Add(i);                    
                    if (File.Exists(app.pathToTxt))
                    {
                        Console.WriteLine($"File {app.pathToTxt} created.");
                    }
                    else if (!File.Exists(app.pathToTxt))
                    {
                        Console.WriteLine($"File wasn't created.");
                    }
                }
            }
            _linesOfTextFile.Clear();

        }
    }
}
