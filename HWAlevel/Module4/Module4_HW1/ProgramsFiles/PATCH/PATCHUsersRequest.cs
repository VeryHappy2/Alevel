using Newtonsoft.Json;

namespace Module4_HW1.ProgramsFiles.PATCH
{
    public sealed class PATCHUsersRequest
    {
        public class Data
        {
            [JsonProperty("id")]
            public int id { get; set; }

            [JsonProperty("email")]
            public string email = "happy@gmail.com";

            [JsonProperty("first_name")]
            public string first_name = "Jhone";

            [JsonProperty("last_name")]
            public string last_name = "Petrovich";

            [JsonProperty("avatar")]
            public string avatar = "Happy";
        }

        public class Root
        {
            [JsonProperty("data")]
            public Data data { get; set; }
        }

    }
}
