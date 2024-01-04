using Microsoft.EntityFrameworkCore;
using Module4_HW4.Configurations;

namespace Module4_HW4.Models
{
    public class AnimalsContext : DbContext
    {
        public DbSet<Breed> Breeds { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Location> Locations { get; set; }

        public AnimalsContext(DbContextOptions<AnimalsContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BreedConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new PetConfig());
        }
    }
}
