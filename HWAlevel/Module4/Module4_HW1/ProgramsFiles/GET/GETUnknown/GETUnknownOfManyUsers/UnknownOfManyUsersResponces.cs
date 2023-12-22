using Newtonsoft.Json;
using System.Collections.Generic;

namespace Module4_HW1.ProgramsFiles.GET.GETUnknown.GETUnknownOfManyUsers
{
    public sealed class UnknownOfManyUsersResponces
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

        public class RootOfUnknown
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
