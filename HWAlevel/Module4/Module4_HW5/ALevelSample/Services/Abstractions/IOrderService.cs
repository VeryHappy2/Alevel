using System.Collections.Generic;
using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IOrderService
{
    Task DeleteOrderAsync(int id);
    Task<string> UpdateOrder(int id, string userId);
    Task<int> AddOrderAsync(string user, List<OrderItem> items);
    Task<Order> GetOrderAsync(int id);
    Task<IReadOnlyList<Order>> GetOrderByUserIdAsync(string id);
}