using Module4_HW4.Models;
using System;
using System.Threading.Tasks;
namespace Module4_HW4
{
    internal class Program
    {
        public static async Task Main()
        {
            await using (AnimalsContext context = new ApplicationFactoryContext().CreateDbContext(Array.Empty<string>()))
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
