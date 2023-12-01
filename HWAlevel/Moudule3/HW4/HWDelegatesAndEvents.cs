using System;

namespace HW4
{
    public delegate int MyDelegate(int x, int y);

    
    public sealed class HWDelegatesAndEvents
    {
        public event MyDelegate MyEvent;
        public int Calc(int num, int num2)
        {
            return num + num2;
        }
        public void MainMethod(int g, int n)
        {
            try
            {
                MyEvent += Calc;
                MyEvent += MultiPly;
                foreach (MyDelegate handler in MyEvent?.GetInvocationList())
                {
                    int result = handler(g, n);
                    Console.WriteLine("Result calculation: " + result);
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
        public int MultiPly(int x, int y)
        {
            return x - y;
        }
    }
}
