using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Module4_HW6.Services.Abstractions;
using Module4_HW6.Services;
using Module4_HW6.App;
using Module4_HW6.Repositories.Abstractions;
using Module4_HW6.Repositories;
using Microsoft.EntityFrameworkCore;
using Module4_HW4.Data;
using System.IO;

void ConfigureServices(ServiceCollection serviceCollection, IConfiguration configuration)
{
    var connectionString = configuration.GetConnectionString("DefaultConnection");
    serviceCollection.AddDbContextFactory<ApplicationContext>(opts => opts.UseSqlServer(connectionString));
    serviceCollection.AddScoped<IDbContextWrapper<ApplicationContext>, DbContextWrapper<ApplicationContext>>();

    serviceCollection
        .AddTransient(typeof(IRepository<>), typeof(Repository<>))
        .AddTransient<App>();
}

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("config.json")
    .Build();

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection, configuration);
var provider = serviceCollection.BuildServiceProvider();

var migrationSection = configuration.GetSection("Migration");
var isNeedMigration = migrationSection.GetSection("IsNeedMigration");

if (bool.Parse(isNeedMigration.Value))
{
    var dbContext = provider.GetService<ApplicationContext>();
    await dbContext!.Database.MigrateAsync();
}

var app = provider.GetService<App>();
await app!.Start();
