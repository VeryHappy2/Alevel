using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Models;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories
{
    public sealed class UpdateAllRepositories : IUpdateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateAllRepositories(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<string> UpdateAsync<T> // method call example: UpdateAsync<Order>(id: 0, ...)
            (                                    // id is a must for call method or if you wanna update of user you must write "userId"
            int id = -1, string firstName = "",
            string lastName = "", string nameOfProduct = "",
            double price = -1, string userId = "", string productId = ""
            )
            where T : class            
        {
            if (typeof(T) == typeof(User))
            {
                var std = await _dbContext.Users
                    .FindAsync(userId);

                if (std != null)
                {
                    await UpdateUserAsync(std, firstName, lastName);
                    return $"User was succassfully updated. Id: {userId}";
                }
                else
                {
                    return $"{userId} wasn't found";
                }
            }
            else if (typeof(T) == typeof(Product))
            {
                var std = await _dbContext.Products
                    .FindAsync(productId);
                if (std != null)
                {
                    await UpdateProductAsync(std, price, nameOfProduct);
                    return $"Product was succassfully updated. Id: {productId}";
                }
                else
                {
                    return $"{productId} wasn't found";
                }
            }
            else if (typeof(T) == typeof(Order))
            {
                var std = await _dbContext.Orders
                    .FindAsync(id);
                if (std != null)
                {
                    await UpdateOrderAsync(std, id, userId);
                    return $"Order was succassfully updated. Id: {id}";
                }
                else
                {
                    return $"Order id:{id} wasn't found";
                }                
            }
            else
            {
                return $"Wrong class";
            }
        }

        private async Task<UserEntity> UpdateUserAsync(UserEntity context, string firstName, string lastName)
        {
            if (firstName == "")
            {
                context.LastName = lastName;
                await _dbContext.SaveChangesAsync();             
            }
            else if (lastName == "")
            {
                context.FirstName = firstName;
                await _dbContext.SaveChangesAsync();                
            }
            else
            {
                context.FirstName = firstName; 
                context.LastName = lastName;
                await _dbContext.SaveChangesAsync();
            }
            return context;
        }
        private async Task<ProductEntity> UpdateProductAsync(ProductEntity context, double price, string name)
        {
            if (price == -1)
            {
                context.Name = name;
                await _dbContext.SaveChangesAsync();
            }
            else if (name == "")
            {
                context.Price = price;
                await _dbContext.SaveChangesAsync();
            }
            else 
            { 
                context.Price = price;
                context.Name = name;            
            }
            return context;
        }
        private async Task<OrderEntity> UpdateOrderAsync(OrderEntity context, int id, string userId)
        {
            if (id == -1)
            {
                context.UserId = userId;
                await _dbContext.SaveChangesAsync();
            }
            else if (userId == "")
            {
                context.Id = id;
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                context.Id = id;
                context.UserId = userId;
            }
            return context;
        }
    }
}
