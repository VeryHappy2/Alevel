using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.POST.PUTERROR400.Login
{
    public sealed partial class POSTOfLoginErrorRequest
    {
        public class Data
        {
            [JsonProperty("id")]
            public string Error = "error";
        }

        public class Root
        {
            [JsonProperty("data")]
            public List<Data> Data;
        }
    }
}
