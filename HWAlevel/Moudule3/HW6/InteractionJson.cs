using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace HW6
{
    public sealed class InteractionJson
    {
        public JsonConfig N {  get; set; }
        public async Task ReadJson()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var textJson = await File.ReadAllTextAsync("JsonFile.json");
            N = JsonSerializer.Deserialize<JsonConfig>(textJson, options);            
        }
        
    }
    public sealed class JsonConfig
    {
        public int Backup { get; set; }
    }
}
