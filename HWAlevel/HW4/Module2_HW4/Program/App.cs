using Microsoft.Extensions.DependencyInjection;
using Module2_HW4.Program;
using Module2_HW4.Program.Intarfaces;
using Module2_HW4.Program.Salads;

var serviceCollection = new ServiceCollection()
    .AddTransient<ISalads, GreekSalad>()
    .AddTransient<ISalads, HerringSalad>()
    .AddSingleton<IBeginning, Beginning>();


var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<IBeginning>();
app!.Start();

