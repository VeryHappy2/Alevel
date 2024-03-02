using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.Extensions.Logging;

namespace ALevelSample.Services;

public class ProductService : BaseDataService<ApplicationDbContext>, IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ILogger<UserService> _loggerService;
    private readonly IUpdateRepository _updateRepository;

    public ProductService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IProductRepository productRepository,
        IUpdateRepository updateRepository,
        ILogger<UserService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _productRepository = productRepository;
        _loggerService = loggerService;
        _updateRepository = updateRepository;
    }

    public async Task<string> DeleteProduct(string id)
    {
        var result = await _productRepository.DeleteProductAsync(id);
        _loggerService.LogInformation($"Product was deleted with Id = {id}");
        return result;
    }

    public async Task<string> UpdateProduct(string id, string name = "", double price = -1)
    {
        var result = await _updateRepository.UpdateAsync<Product>(productId: id, nameProduct: name, price: price);
        _loggerService.LogInformation($"Product was updated with name = {name}");
        return result;
    }
    public async Task<string> AddProductAsync(string name, double price)
    {
        var id = await _productRepository.AddProductAsync(name, price);
        _loggerService.LogInformation($"Created product with Id = {id}");
        return id;
    }

    public async Task<Product> GetProductAsync(string id)
    {
        var result = await _productRepository.GetProductAsync(id);

        if (result == null)
        {
            _loggerService.LogWarning($"Not founded product with Id = {id}");
            return null!;
        }

        return new Product()
        {
            Id = result.Id,
            Name = result.Name,
            Price = result.Price
        };
    }
}