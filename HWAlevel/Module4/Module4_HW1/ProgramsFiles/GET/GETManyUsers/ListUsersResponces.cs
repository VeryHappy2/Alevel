using Newtonsoft.Json;
using System.Collections.Generic;

namespace Module4_HW1.ProgramsFiles.GET.GETmanyusers
{
    public sealed class ListUsersResponces()
    {
        public class Data
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("first_name")]
            public string FirstName { get; set; }

            [JsonProperty("last_name")]
            public string LastName { get; set; }

            [JsonProperty("avatar")]
            public string Avatar { get; set; }
        }

        public class Root
        {
            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("per_page")]
            public int PerPage { get; set; }

            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("total_pages")]
            public int TotalPages { get; set; }

            [JsonProperty("data")]
            public List<Data> Data { get; set; }
        }

    }
}
