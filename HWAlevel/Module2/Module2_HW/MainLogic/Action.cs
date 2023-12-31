using Module2_HW.CustomExeptions;
using System;

namespace Module2_HW.MainLogic
{
    public sealed class Action
    {
        public void StartMethod()
        {
            Logger.Log("Info", "Start method: StartMethod");
            Console.WriteLine("Info");
        }

        public void SkippedLogic()
        {
            Logger.Log("Warning", "Action got this custom Exception: Skipped logic in method", true);
            Console.WriteLine("Warning" );

            throw new BusinessException("Skipped logic in method");
        }

        public void BrokeLogic()
        {
            Logger.Log("Error", "Action failed by reason: I broke a logic", true);
            Console.WriteLine("Error");

            throw new Exception("I broke a logic");
        }
    }
}
