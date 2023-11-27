using System;

namespace HW3.Classes
{
    internal class Class2 : Class1
    {
        private int _number1 = 0;
        public delegate int DMultiply(int param1, int param2);
        public bool Calc(DMultiply multiply, int param1, int param2)
        {
            int result = multiply(param1, param2);

            _number1 = result;
            return Result(param1);
        }
        public bool Result(int num2)
        {            
            int remainder = _number1 % num2;
            return remainder == 0;
        }
        public void Show(bool show)
        {
            Console.WriteLine(show);
        }
    }
}