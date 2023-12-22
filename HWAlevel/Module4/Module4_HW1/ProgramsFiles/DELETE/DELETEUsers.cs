using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.DELETE
{
    public class DELETEUsers
    {
        private ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/users/2";
        public DELETEUsers(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTPOfManyUsers()
        {
            try
            {

                var client = _clientFactory.clientFactory.CreateClient();
                HttpResponseMessage result = await client.DeleteAsync(_url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var listRoot = JsonConvert.DeserializeObject<DELETEUsersResponce.Root>(content);

                    Console.WriteLine("I'm suprice that it works");
                }
                else
                {
                    Console.WriteLine(result.StatusCode);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
