using HW3.Classes;
using System;
using System.Diagnostics;

namespace HW3
{
    public sealed class MainProgram
    {
        private static void Main()
        {
            Class1 class1 = new Class1();
            Class2 class2 = new Class2();
            
            Class2.DMultiply multiply = class1.Multiply;

            Console.WriteLine("What number 1?");
            int answer1 = int.Parse(Console.ReadLine());

            Console.WriteLine("What number 2?");
            int answer2 = int.Parse(Console.ReadLine());

            bool mainResult = class2.Calc(multiply, answer1, answer2);
            class2.Show(mainResult);
        }
    }
}
