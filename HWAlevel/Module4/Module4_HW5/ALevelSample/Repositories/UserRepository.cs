using System;
using System.Threading.Tasks;
using ALevelSample.Data;
using ALevelSample.Data.Entities;
using ALevelSample.Repositories.Abstractions;
using ALevelSample.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;

    public UserRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public async Task<string> AddUserAsync(string firstName, string lastName)
    {
        var user = new UserEntity()
        {
            Id = Guid.NewGuid().ToString(),
            FirstName = firstName,
            LastName = lastName
        };

        await _dbContext.Users.AddAsync(user);
        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            
            var innerException = ex.InnerException;
            
            Console.WriteLine(innerException.Message); //Invalid  column name "UserId"
        }

        return user.Id;
    }

    public async Task<UserEntity?> GetUserAsync(string id)
    {
        return await _dbContext.Users.FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<string> DeleteUserAsync(string id)
    {
        var deletedUser = await _dbContext.Users
            .FindAsync(id);

        if (deletedUser != null)
        {
            _dbContext.Remove(deletedUser);
            await _dbContext.SaveChangesAsync();
            return $"User with {id} was sacussfully deleted";
        }
        else
        {
            return $"User with {id} wasn't found";
        }
    }
}