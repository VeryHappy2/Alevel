using Module4_HW1.ProgramsFiles.GET.GETmanyusers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;

namespace Module4_HW1.ProgramsFiles.GET.GETUnknown.GETUnknownOfManyUsers
{
    public sealed class GETUnknownOfManyUsers
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/unknown";
        public GETUnknownOfManyUsers(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTPOfUnknownUsers()
        {
            try
            {

                var client = _clientFactory.clientFactory.CreateClient();
                HttpResponseMessage result = await client.GetAsync(_url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var listRoot = JsonConvert.DeserializeObject<UnknownOfManyUsersResponces.RootOfUnknown>(content);

                    Console.WriteLine("Unknown users:");
                    Console.WriteLine($"Page: {listRoot.Page}");
                    Console.WriteLine($"Per Page: {listRoot.PerPage}");
                    Console.WriteLine($"Total: {listRoot.Total}");
                    Console.WriteLine($"Total Pages: {listRoot.TotalPages}\n");

                    foreach (var item in listRoot.Data)
                    {
                        Console.WriteLine($"ID: {item.Id}");
                        Console.WriteLine($"Color: {item.Color}");
                        Console.WriteLine($"Year: {item.Year}");
                        Console.WriteLine($"Name: {item.Name}");
                        Console.WriteLine($"Avatar: {item.PantoneValue}\n");

                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
