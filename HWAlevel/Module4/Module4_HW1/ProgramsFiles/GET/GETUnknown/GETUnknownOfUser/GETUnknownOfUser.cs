using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.GET.GETUnknown.GETUnknownOfUser
{
    public sealed class GETUnknownOfUser
    {
        private readonly ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/unknown/2";

        public GETUnknownOfUser(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ReadJSONHTTPOfOneUser()
        {
            try
            {
                var client = _clientFactory.clientFactory.CreateClient();
                HttpResponseMessage result = await client.GetAsync(_url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var listuser = JsonConvert.DeserializeObject<GETUnknownOfUserResponce.Root>(content);

                    Console.WriteLine("Unknown one user:");
                    Console.WriteLine($"id: {listuser.Data.Id}");
                    Console.WriteLine($"email: {listuser.Data.Name}");
                    Console.WriteLine($"first name: {listuser.Data.Year}");
                    Console.WriteLine($"last name: {listuser.Data.Color}");
                    Console.WriteLine($"avatar: {listuser.Data.PantoneValue}\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
