using System.Configuration;

namespace LoggerDemo
{
    internal class Action
    {
        public bool Status { get; set; }

        readonly public string logPath = ConfigurationManager.AppSettings["logPath"];

        public Logger logger = new Logger();

        public bool ResultInfo(string message)
        {
            logger.LogInfo($"Start method: {message} ");

            Status = true;
            return Status;
        }
        public bool ResultWarning(string message)
        {
            logger.LogWarning($"Start method: {message}");
            
            Status = true;
            return Status;
        }
        public bool ResultError(string message)
        {

            logger.LogError($"Error: {message}");
            Status = true;
            return Status;
        }

    }
}
