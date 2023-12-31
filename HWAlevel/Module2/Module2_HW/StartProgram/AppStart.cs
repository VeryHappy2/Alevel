using Module2_HW.CustomExeptions;
using Module2_HW.MainLogic;
using System;
using Action = Module2_HW.MainLogic.Action;

namespace Module2_HW.StartProgram
{

    public class App
    {
        public static void Run()
        {
            Action actions = new Action();
            Random random = new Random();

            for (int counter = 0; counter < 100; counter++)
            {
                int randomAction = random.Next(1, 4);

                try
                {
                    switch (randomAction)
                    {
                        case 1:
                            actions.StartMethod();
                            break;
                        case 2:
                            actions.SkippedLogic();
                            break;
                        case 3:
                            actions.BrokeLogic();
                            break;
                    }
                }
                catch (BusinessException ex)
                {
                    Logger.Log("Warning", $"Action got this custom Exception: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Logger.Log("Error", $"Action failed by reason: {ex.Message}");
                }
            }
        }

    }
}
