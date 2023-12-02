using System;
using System.Threading.Tasks;

namespace Module3_HW5
{
    internal sealed class Program
    {
        static async Task Main()
        {
            Read read = new Read();
            await read.MethodRead();
            Console.WriteLine($"{read.hello.Trim()} {read.world.Trim()}" );
        }
    }
}