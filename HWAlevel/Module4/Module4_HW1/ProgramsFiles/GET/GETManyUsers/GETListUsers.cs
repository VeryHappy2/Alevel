using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace Module4_HW1.ProgramsFiles.GET.GETmanyusers
{
    public sealed class GETListUsers
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/users?page=2";
        public GETListUsers(IHttpClientFactory clientFactory)
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
                    var listRoot = JsonConvert.DeserializeObject<ListUsersResponces.Root>(content);

                    Console.WriteLine("Many users:");
                    Console.WriteLine($"Page: {listRoot.Page}");
                    Console.WriteLine($"Per Page: {listRoot.PerPage}");
                    Console.WriteLine($"Total: {listRoot.Total}");
                    Console.WriteLine($"Total Pages: {listRoot.TotalPages}");
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
