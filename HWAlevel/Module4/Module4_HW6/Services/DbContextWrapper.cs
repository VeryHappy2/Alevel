using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Module4_HW6.Services.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Module4_HW6.Services
{
    public class DbContextWrapper<T> : IDbContextWrapper<T>
        where T : DbContext
    {
        private readonly T _dbContext;

        public DbContextWrapper(
            IDbContextFactory<T> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public T DbContext => _dbContext;

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
