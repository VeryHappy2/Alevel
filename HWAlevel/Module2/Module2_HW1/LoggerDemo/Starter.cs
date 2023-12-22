using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDemo
{
    internal class Starter
    {
        public static void Run()
        {
            Action action = new Action();

            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int index = random.Next(3);

                if (index == 0)
                {
                    action.ResultInfo("Method1");
                }
                else if (index == 1) 
                {
                    action.ResultWarning("Method2");
                }
                else
                {
                    action.ResultError("I broke a logic in Method3");
                    
                }

            }


        }

    }
}
