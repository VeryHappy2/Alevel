using HW6;
using System;
using System.IO;
using System.Threading.Tasks;

public sealed class App
{
    public string pathToTxt {  get; set; }
    public string backupFolder = "Backup";

    static async Task Main()
    {
        App app = new App();
        Logger logger = new Logger();

        if (Directory.Exists(app.backupFolder))
        {
            Directory.CreateDirectory(app.backupFolder);
            Console.WriteLine("Folder was created");
        }

        await Task.WhenAll(
            logger.WriteLog()
            );
    }
    public async Task CreateBackUpFile()
    {
        await Task.Delay(5000);
        string nameTxt = DateTime.Now.ToString("yyyy MM dd HH mm") + ".txt";
        pathToTxt = Path.Combine(backupFolder, nameTxt);
    }
}

