using MVC.ViewModels;

namespace MVC.Services.Interfaces
{
	public interface IBasketService
	{
		Task<List<Basket>> GetBasket();
	}
}
