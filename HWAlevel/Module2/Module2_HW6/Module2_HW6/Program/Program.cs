using Microsoft.Extensions.DependencyInjection;
using Module2_HW6.Program.Connect;

var serviceCollection = new ServiceCollection()
    .AddTransient<AnswerToUser>()
    .AddSingleton<App>();

var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<App>();
app!.Start();