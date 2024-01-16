using System;
using Microsoft.EntityFrameworkCore;
using Module4_HW4.Data;
using Module4_HW6.Data.Entities;
using Module4_HW6.Repositories.Abstractions;
using Module4_HW6.Services.Abstractions;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Module4_HW6.Repositories
{
    public class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        private ApplicationContext _dbContext;
        private DbSet<T> _dbSet;

        public Repository(IDbContextWrapper<ApplicationContext> context)
        {
            _dbContext = context.DbContext;
        }

        public async Task<int> AddAsync(T entity)
        {
            var item = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return item.Entity.Id;
        }

        public async Task<string?> DeleteAsync(int id)
        {
            var result = await _dbContext.Set<T>()
                .FindAsync(id);
            if(result != null) 
            {
                _dbContext.Set<T>().Remove(result);
                await _dbContext.SaveChangesAsync();
                return $"Object with id: {id} was saccussfully removed";
            }
            else
            {
                return $"Id: {id} wasn't found";
            }            
        }

        public async Task<string?> UpdateAsync(int id, T entity)
        {

            var result = await _dbContext.Pets.FindAsync(id);

            if (result != null)
            {
                _dbContext.Entry(result).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();

                return result.Id.ToString();
            }
            else
            {
                Console.WriteLine($"Entity with Id {entity.Id} not found.");
                return null;
            }

        }
    }
}
