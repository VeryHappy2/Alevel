using System.Threading.Tasks;
using ALevelSample.Models;

namespace ALevelSample.Services.Abstractions;

public interface IProductService
{
    Task<string> DeleteProduct(string id);
    Task<string> UpdateProduct(string id, string name = "", double price = -1);
    Task<string> AddProductAsync(string name, double price);
    Task<Product> GetProductAsync(string id);
}