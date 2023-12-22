using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW1.ProgramsFiles.GET.GETERROR404
{
    public sealed partial class GETERROR404
    {


        private ClientFactory _clientFactory = new ClientFactory();
        private readonly string _url = "https://reqres.in/api/users/23";
        public GETERROR404(IHttpClientFactory clientFactory)
        {
            _clientFactory.clientFactory = clientFactory;
        }

        public async Task ERROR404Num1()
        {
            try
            {

                var client = _clientFactory.clientFactory.CreateClient();
                HttpResponseMessage result = await client.GetAsync(_url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    string content = await result.Content.ReadAsStringAsync();
                    var ERROR404 = JsonConvert.DeserializeObject<ERROR404Responce>(content);

                    Console.WriteLine($"I'm suprised that it work. ERROR404: {ERROR404}");


                }
                else if (result.StatusCode == HttpStatusCode.NotFound)
                {
                    Console.WriteLine($"URL: {_url}, ERROR404: NOT FOUND \n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
