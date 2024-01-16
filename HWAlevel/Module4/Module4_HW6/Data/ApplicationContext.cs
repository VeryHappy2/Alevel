using Microsoft.EntityFrameworkCore;
using Module4_HW4.Data.Configurations;
using Module4_HW4.Data.Entities;
using Module4_HW6.Data.Entities;
using System;
using System.Threading.Tasks;

namespace Module4_HW4.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<BreedEntity> Breeds { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<PetEntity> Pets { get; set; }
        public DbSet<LocationEntity> Locations { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BreedConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new LocationConfig());
            modelBuilder.ApplyConfiguration(new PetConfig());
            modelBuilder.UseHiLo();
        }

    }
}
