using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Module4_HW4.Models;

namespace Module4_HW4
{
    public sealed class ApplicationFactoryContext : IDesignTimeDbContextFactory<AnimalsContext>
    {
        public AnimalsContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=localhost;Initial Catalog=Pets;TrustServerCertificate=True;Integrated Security=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<AnimalsContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

            return new AnimalsContext(options);
        }
    }
}
