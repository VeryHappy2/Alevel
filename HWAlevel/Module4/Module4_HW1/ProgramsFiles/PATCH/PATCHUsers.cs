using Module4_HW1.ProgramsFiles.PUT.PUTOfManyUsers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace Module4_HW1.ProgramsFiles.PATCH
{
    public sealed class PATCHUsers
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/users/2";
        public PATCHUsers(IHttpClientFactory clientFactory)
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
                HttpResponseMessage listRoot = await client.PatchAsync(_url, content);

                Console.WriteLine($"URL: {_url}.Patch was sended");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
