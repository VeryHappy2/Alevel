using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.POST.PUTOfRegister
{
    public sealed class POSTOfRegisterRequest
    {
        public class Data
        {
            [JsonProperty("token")]
            public string token = "ArfsaqQwfWfHJbvd";
        }

        public class Root
        {

            [JsonProperty("data")]
            public List<Data> Data { get; set; }
        }
    }
}
