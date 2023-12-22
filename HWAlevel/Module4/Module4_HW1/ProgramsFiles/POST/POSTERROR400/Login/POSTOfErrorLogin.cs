using Module4_HW1.ProgramsFiles.POST.PUTOfLogin;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.POST.PUTERROR400.Login
{
    public sealed partial class POSTOfErrorLogin
    {


        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/login";
        public POSTOfErrorLogin(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTP()
        {
            try
            {
                var client = _clientFactory.clientFactory.CreateClient();
                var updatedUsers = new POSTOfLoginErrorRequest.Root();
                string jsonData = JsonConvert.SerializeObject(updatedUsers);

                StringContent content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage listRoot = await client.PostAsync(_url, content);

                Console.WriteLine($"URL: {_url}.Post was sended to the login (error)");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
