using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.POST.PUTERROR400.Register
{
    public partial class POSTOfErrorRegisterRequest
    {
        public class Data
        {
            [JsonProperty("error")]
            public int Error = 0;
        }

        public class Root
        {
            [JsonProperty("data")]
            public List<Data> Data { get; set; }
        }
    }
}
