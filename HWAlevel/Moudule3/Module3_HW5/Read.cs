using System.IO;
using System.Threading.Tasks;

namespace Module3_HW5
{
    public sealed class Read
    {
        public string hello, world = "";
        public async Task MethodRead()
        {
            using (StreamReader reader = new StreamReader("Hello.txt")) 
            {
                 hello = await reader.ReadToEndAsync();                
            }
            using (StreamReader reader = new StreamReader("World.txt"))
            {
                 world = await reader.ReadToEndAsync();
            }            
        }
    }
}
