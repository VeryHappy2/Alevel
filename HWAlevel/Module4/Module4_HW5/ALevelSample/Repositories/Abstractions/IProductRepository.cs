using System.Threading.Tasks;
using ALevelSample.Data.Entities;

namespace ALevelSample.Repositories.Abstractions;

public interface IProductRepository
{
    Task<string> DeleteProductAsync (string id);
    Task<string> AddProductAsync(string name, double price);
    Task<ProductEntity?> GetProductAsync(string id);
}