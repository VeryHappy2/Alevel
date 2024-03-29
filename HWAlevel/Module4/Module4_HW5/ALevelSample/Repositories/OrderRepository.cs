using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;

namespace ALevelSample.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _dbContext;

    public OrderRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<string> DeleteOrderAsync(int id) // remove id of the class order
    {
        var selectId = await _dbContext.Orders
            .FindAsync(id);

        if (selectId != null)
        {
            _dbContext.Orders.Remove(selectId);
            await _dbContext.SaveChangesAsync();
            return $"Id: {id} was successfully removed";
        }
        else
        {
            return $"Id: {id} wasn't removed";
        }
    }

    public async Task<int> AddOrderAsync(string user, List<OrderItem> items)
    {
        var result = await _dbContext.Orders.AddAsync(new OrderEntity()
        {
            UserId = user
        });

        await _dbContext.OrderItems.AddRangeAsync(items.Select(s => new OrderItemEntity()
        {
            Count = s.Count,
            OrderId = result.Entity.Id,
            ProductId = s.ProductId
        }));

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

    public async Task<OrderEntity?> GetOrderAsync(int id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<IEnumerable<OrderEntity>?> GetOrderByUserIdAsync(string id)
    {
        return await _dbContext.Orders.Include(i => i.OrderItems).Where(f => f.UserId == id).ToListAsync();
    }
}