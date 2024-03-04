using Module2_HW.MainLogic;
using Newtonsoft.Json;
using System;

public class Logger
{
    public static void Log(string logType, string message, bool isJson = false)
    {
        FileService fileService = new FileService();
        if (isJson)
        {
            var logEntry = new { LogTime = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"), LogType = logType, Message = message };
            string jsonLog = JsonConvert.SerializeObject(logEntry, Formatting.Indented);
            fileService.WriteToFile(jsonLog, "json");
        }
        else
        {
            string logEntry = $"{DateTime.Now:MM/dd/yyyy hh:mm:ss.fff tt}: {logType}: {message}";
            fileService.WriteToFile(logEntry, "txt");
        }
    }
}