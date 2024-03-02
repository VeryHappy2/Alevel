using System;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<string> DeleteProductAsync(string id) // Delete product
    {
        var selectId = await _dbContext.Products
            .FindAsync(id);

        if (selectId != null)
        {
            await _dbContext.SaveChangesAsync();
            return "Product was successfully deleted";
        }
        else
        {
            return "Product wasn't deleted";
        }
    }

    public async Task<string> AddProductAsync(string name, double price)
    {
        var product = new ProductEntity()
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Price = price
        };

        var result = await _dbContext.Products.AddAsync(product);
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {

            var innerException = ex.InnerException;

            Console.WriteLine(innerException.Message); 
        }

        return result.Entity.Id;
    }

    public async Task<ProductEntity?> GetProductAsync(string id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(f => f.Id == id);
    }
}