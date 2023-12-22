using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.DELETE
{
    public class DELETEUsersResponce
    {
        public class Data
        {
            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("email")]
            public string email { get; set; }

            [JsonProperty("first_name")]
            public string first_name { get; set; }

            [JsonProperty("last_name")]
            public string last_name { get; set; }

            [JsonProperty("avatar")]
            public string avatar { get; set; }
        }

        public class Root
        {
            [JsonProperty("data")]
            public List<Data> Data { get; set; }

        }
    }
}
