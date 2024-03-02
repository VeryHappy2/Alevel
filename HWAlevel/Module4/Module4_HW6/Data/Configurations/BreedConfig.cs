using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW6.Data.Entities;

namespace Module4_HW4.Data.Configurations
{
    public class BreedConfig : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder
                .HasKey(c => c.Id);
            builder
                .Property(c => c.Id)
                .HasColumnName("id");
            builder
                .HasOne(b => b.Category)
                .WithMany(p => p.Breeds)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .Property(c => c.BreedName)
                .HasColumnName("breed_name")
                .IsRequired();

            //builder.HasData(new[]
            //{
            //    new BreedEntity
            //    {
            //        Id = 1,
            //        BreedName = "Scottish",
            //    }
            //});
        }
    }
}
