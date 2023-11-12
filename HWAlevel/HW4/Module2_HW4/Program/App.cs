using Microsoft.Extensions.DependencyInjection;
using Module2_HW4.Program;
using Module2_HW4.Program.Intarfaces;
using Module2_HW4.Program.Salads;

var serviceCollection = new ServiceCollection()
    .AddSingleton<IBeginning, Beginning>()
    .AddTransient<ISalads, GreekSalad>()
    .AddTransient<ISalads, HerringSalad>();

var provider = serviceCollection.BuildServiceProvider();

var app = provider.GetService<IBeginning>();
app!.Start();

