using Catalog.Host.Configurations;
using Catalog.Host.Data;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Extensions;
using Infrastructure.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Catalog.Host.Repositories.Abstractions;

var configuration = GetConfiguration();

//build config

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
	options.Filters.Add(typeof(HttpGlobalExceptionFilter));
})
	.AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Title = "eShop- Catalog HTTP API",
		Version = "v1",
		Description = "The Catalog Service HTTP API"
	});

	var authority = configuration["Authorization:Authority"];
	options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
	{
		Type = SecuritySchemeType.OAuth2,
		Flows = new OpenApiOAuthFlows()
		{
			Implicit = new OpenApiOAuthFlow()
			{
				AuthorizationUrl = new Uri($"{authority}/connect/authorize"),
				TokenUrl = new Uri($"{authority}/connect/token"),
				Scopes = new Dictionary<string, string>()
				{
					{"mvc", "website" },
					{"catalog.catalogitem", "catalog.catalogitem" },
					{"catalog.catalogbrand", "catalog.catalogbrand" },
					{"catalog.catalogtype", "catalog.catalogtype" },
				}
			}
		}
	});

	options.OperationFilter<AuthorizeCheckOperationFilter>();
});

builder.Services.AddControllers();
builder.Services.Configure<CatalogConfig>(configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<ICatalogItemRepository, CatalogItemRepository>();
builder.Services.AddTransient<ICatalogService, CatalogService>();
builder.Services.AddTransient<ICatalogItemService, CatalogItemService>();
builder.Services.AddTransient<ICatalogTypeService, CatalogTypeService>();
builder.Services.AddTransient<ICatalogBrandService, CatalogBrandService>();
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<ICatalogBffRepository, CatalogBffRepository>();

builder.Services.AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(configuration["ConnectionString"]));
builder.Services.AddScoped<IDbContextWrapper<ApplicationDbContext>, DbContextWrapper<ApplicationDbContext>>();

builder.Services.AddCors(options =>
{
	options.AddPolicy(
		"CorsPolicy",
		builder => builder
			.SetIsOriginAllowed((host) => true)
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials());
});
builder.Services.AddAuthorization(configuration);

//app option

var app = builder.Build();

app.UseSwagger()
	.UseSwaggerUI(setup =>
	{
		setup.SwaggerEndpoint($"{configuration["PathBase"]}/swagger/v1/swagger.json", "Catalog.API V1");
		setup.OAuthClientId("catalogswaggerui");
		setup.OAuthAppName("Catalog Swagger UI");
	});
app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
    LogRequest(logger, context.Request);

    // Call the next middleware in the pipeline
    await next.Invoke();

    LogResponse(logger, context.Response);
});
app.UseRouting();
app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
    endpoints.MapControllers();
});


CreateDbIfNotExists(app);

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}

void LogRequest(ILogger<Program> logger, HttpRequest request)
{
	logger.LogInformation($"Request: {request.Method} {request.Path}");

	foreach (var header in request.Headers)
	{
		logger.LogInformation($"{header.Key}: {header.Value}");
    }
	
}

void LogResponse(ILogger<Program> logger, HttpResponse response)
{

    logger.LogInformation($"Response: {response.StatusCode}");

    foreach (var header in response.Headers)
    {
        logger.LogInformation($"{header.Key}: {header.Value}");
    }
}

void CreateDbIfNotExists(IHost host)
{
    using (var scope = host.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            DbInitializer.Initialize(context).Wait();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }
}