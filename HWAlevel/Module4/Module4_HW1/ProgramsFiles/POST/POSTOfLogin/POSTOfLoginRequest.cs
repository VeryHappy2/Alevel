using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.POST.PUTOfLogin
{
    public class POSTOfLoginRequest
    {
        public class Data
        {
            [JsonProperty("id")]
            public int Id = 0;

            [JsonProperty("email")]
            public string Email = "happy@gmail.com";

            [JsonProperty("avatar")]
            public string Avatar = "Happy";
        }

        public class Root
        {
            [JsonProperty("total_pages")]
            public int TotalPages = 5;

            [JsonProperty("data")]
            public List<Data> Data { get; set; }
        }
    }
}
