using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.POST.PUTOfLogin
{
    public sealed class POSTOfLogin
    {


        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/users";
        public POSTOfLogin(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTP()
        {
            try
            {
                var client = _clientFactory.clientFactory.CreateClient();
                var updatedUsers = new POSTOfLoginRequest.Root();
                string jsonData = JsonConvert.SerializeObject(updatedUsers);

                StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage listRoot = await client.PostAsync(_url, content);

                Console.WriteLine($"URL: {_url} Post was sended in the login");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
