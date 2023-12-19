using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.GET.GETUnknown.GETUnknownOfUser
{
    public sealed class GETUnknownOfUserResponce
    {
        public class Data
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("year")]
            public int Year { get; set; }

            [JsonProperty("color")]
            public string Color { get; set; }

            [JsonProperty("pantone_value")]
            public string PantoneValue { get; set; }
        }

        public sealed class Root
        {
            [JsonProperty("data")]
            public Data Data { get; set; }
        }
    }
}
