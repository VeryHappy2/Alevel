using System;
using System.Collections.Concurrent;
using System.Linq;

namespace HW4
{
    public sealed class HWLinq
    {
        public void HWLinqMethod()
        {
            ConcurrentBag<int> contacts = new ConcurrentBag<int> { 965479056, 973456320, 985467892, 962435467 };
            var variable = contacts.FirstOrDefault(contacts => contacts < 985467892);

            Console.WriteLine("Method FirstOrDefault:" + variable);
            var variable1 = contacts
                .Where(contacts => contacts < 985467892)
                .Select(contacts => contacts + 5);
            foreach (var linq in variable1)
            {
                Console.WriteLine("\nMethods Where, Select:" + linq);
            }

            if(contacts.Any(contacts => contacts > 973456320))
            {
                Console.WriteLine("Right");
            }
            else
            {
                Console.WriteLine("Don't right");
            }

            if (contacts.All(contacts => contacts < 100000000000))
            {
                Console.WriteLine("The mostest");
            }
            else
            {
                Console.WriteLine("Text");
            }
            var variable3 = contacts
                .LastOrDefault(contacts => contacts < 973456320);
            Console.WriteLine("Method FirstOrDefault: " + variable3);
        }
    }
}
