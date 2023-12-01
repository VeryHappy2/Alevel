using System.Collections.Concurrent;
using System.Linq;
using System;

namespace HW4
{
    public sealed class Program
    {
        
        static void Main()
        {
            HWLinq hwLinq = new HWLinq();
            hwLinq.HWLinqMethod();

            HWDelegatesAndEvents hWDelegatesAndEvents = new HWDelegatesAndEvents();

            Console.WriteLine("Number 1");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number 2");
            int num2 = Convert.ToInt32(Console.ReadLine());

            hWDelegatesAndEvents.MainMethod(num1, num2);

        }
    }
}