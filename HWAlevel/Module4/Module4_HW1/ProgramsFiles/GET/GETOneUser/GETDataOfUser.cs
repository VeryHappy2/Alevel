using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.GET.GEToneuser
{
    public sealed class GETDataOfUser
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _urlOfOneUser = "https://reqres.in/api/users/2";

        public GETDataOfUser(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTPOfOneUser()
        {
            try
            {
                var client = _clientFactory.clientFactory.CreateClient();
                HttpResponseMessage result = await client.GetAsync(_urlOfOneUser);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var listuser = JsonConvert.DeserializeObject<RootOfOneUser>(content);
                    Console.WriteLine("One user:");
                    Console.WriteLine($"id: {listuser.Data.Id}");
                    Console.WriteLine($"email: {listuser.Data.Email}");
                    Console.WriteLine($"first name: {listuser.Data.FirstName}");
                    Console.WriteLine($"last name: {listuser.Data.LastName}");
                    Console.WriteLine($"avatar: {listuser.Data.Avatar}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

