using MVC.Services.Interfaces;
using MVC.ViewModels;

namespace MVC.Services
{
	public class BasketServise : IBasketService
	{
		private readonly IOptions<AppSettings> _settings;
		private readonly IHttpClientService _httpClient;
		private readonly ILogger<CatalogService> _logger;

		public BasketServise(IHttpClientService httpClient, ILogger<CatalogService> logger, IOptions<AppSettings> settings)
		{
			_httpClient = httpClient;
			_settings = settings;
			_logger = logger;
		}

		public async Task<List<Basket>> GetBasket()
		{
			var serverList = await _httpClient.SendAsync<List<Basket>, object>
			($"{_settings.Value.BasketUrl}/getbrands", HttpMethod.Post, null);
			return serverList;
		}

	}
}
