using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.PUT.PUTOfManyUsers
{
    public sealed class PUTOfManyUsers
    {


        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/users/2";
        public PUTOfManyUsers(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTPOfManyUsers()
        {
            try
            {
                var client = _clientFactory.clientFactory.CreateClient();
                var updatedUsers = new PUTOfManyUsersRequest.Root();
                string jsonData = JsonConvert.SerializeObject(updatedUsers);

                StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage listRoot = await client.PutAsync(_url, content);

                Console.WriteLine($"URL: {_url}.Put was sended");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
