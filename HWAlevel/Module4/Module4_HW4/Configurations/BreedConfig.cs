using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW4.Models;

namespace Module4_HW4.Configurations
{
    public class BreedConfig : IEntityTypeConfiguration<Breed>
    {
        public void Configure (EntityTypeBuilder<Breed> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .ValueGeneratedNever();
            builder
                .Property(c => c.BreedName)
                .HasColumnName("breed_name");
            builder.HasData(new[]
            {
                new Breed
                {
                    BreedName = "Scotland",
                    Id = 0,
                    CategoryId = 0,                    
                }
            });
        }
    }
}
