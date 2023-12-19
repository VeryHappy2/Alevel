using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace Module4_HW1.ProgramsFiles.GET.GETmanyusers
{
    public sealed class GETUsersDelay
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/users?delay=3";
        public GETUsersDelay(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTPOfManyUsers()
        {
            try
            {

                var client = _clientFactory.clientFactory.CreateClient();
                HttpResponseMessage result = await client.GetAsync(_url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var listRoot = JsonConvert.DeserializeObject<UsersDelayResponces.Root>(content);

                    Console.WriteLine("Users delay:");
                    Console.WriteLine($"Page: {listRoot.Page}");
                    Console.WriteLine($"Per Page: {listRoot.PerPage}");
                    Console.WriteLine($"Total: {listRoot.Total}");
                    Console.WriteLine($"Total Pages: {listRoot.TotalPages}\n");
                    foreach (var item in listRoot.Data)
                    {


                        Console.WriteLine($"ID: {item.Id}");
                        Console.WriteLine($"Email: {item.Email}");
                        Console.WriteLine($"First Name: {item.FirstName}");
                        Console.WriteLine($"Last Name: {item.LastName}");
                        Console.WriteLine($"Avatar: {item.Avatar}");
                        Console.WriteLine();

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
