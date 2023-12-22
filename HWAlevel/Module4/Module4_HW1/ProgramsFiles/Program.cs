using Microsoft.Extensions.DependencyInjection;
using Module4_HW1.ProgramsFiles.GET.GETmanyusers;
using Module4_HW1.ProgramsFiles.GET.GEToneuser;
using System.Net.Http;
using System.Threading.Tasks;
using Module4_HW1.ProgramsFiles.GET.GETUnknown.GETUnknownOfManyUsers;
using Module4_HW1.ProgramsFiles.GET.GETUnknown.GETUnknownOfUser;
using Module4_HW1.ProgramsFiles.DELETE;
using Module4_HW1.ProgramsFiles.PUT.PUTOfManyUsers;
using Module4_HW1.ProgramsFiles.POST.PUTERROR400.Login;
using Module4_HW1.ProgramsFiles.POST.PUTERROR400.Register;
using Module4_HW1.ProgramsFiles.POST.PUTOfLogin;
using Module4_HW1.ProgramsFiles.POST.PUTOfRegister;
using Module4_HW1.ProgramsFiles.PATCH;

namespace Module4_HW1.ProgramsFiles
{
    class Program
    {
        static async Task Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddHttpClient()
                .BuildServiceProvider();

            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

            var GETDataOfUser = new GETDataOfUser(httpClientFactory);
            var GETListUsers = new GETListUsers(httpClientFactory);
            var GETERROR404Num1 = new GET.GETERROR404.GETERROR404(httpClientFactory);
            var GETERROR404Num2 = new GET.GETERROR404.ERROR404_2_.GETERROR404(httpClientFactory);
            var GETUnknownUsers = new GETUnknownOfManyUsers(httpClientFactory);
            var GETUnknownUser = new GETUnknownOfUser(httpClientFactory);
            var DELETEUsers = new DELETEUsers(httpClientFactory);
            var PUTOfManyUsers = new PUTOfManyUsers(httpClientFactory);
            var GETUsersDelay = new GETUsersDelay(httpClientFactory);
            var POSTOfErrorLogin = new POSTOfErrorLogin(httpClientFactory);
            var POSTOfErrorRegister = new POSTOfErrorRegister(httpClientFactory);
            var POSTOfLogin = new POSTOfLogin(httpClientFactory);
            var POSTOfRegister = new POSTOfRegister(httpClientFactory);
            var PATCHUsers = new PATCHUsers(httpClientFactory);

            await PATCHUsers.ReadJSONHTTPOfManyUsers();
            await POSTOfRegister.ReadJSONHTTP();
            await POSTOfLogin.ReadJSONHTTP();
            await POSTOfErrorRegister.ReadJSONHTTP();
            await POSTOfErrorLogin.ReadJSONHTTP();
            await GETUsersDelay.ReadJSONHTTPOfManyUsers();
            await PUTOfManyUsers.ReadJSONHTTPOfManyUsers();
            await DELETEUsers.ReadJSONHTTPOfManyUsers();
            await GETUnknownUser.ReadJSONHTTPOfOneUser();
            await GETUnknownUsers.ReadJSONHTTPOfUnknownUsers();
            await GETERROR404Num2.ERROR404Num2();
            await GETERROR404Num1.ERROR404Num1();
            await GETListUsers.ReadJSONHTTPOfManyUsers();
            await GETDataOfUser.ReadJSONHTTPOfOneUser();
        }
    }
}
