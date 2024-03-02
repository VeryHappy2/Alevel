using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW6.Data.Entities;
using System.Reflection.Emit;

namespace Module4_HW4.Data.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(c => c.Id)
                .HasColumnName("id");
            builder
                .Property(c => c.CategoryName)
                .HasColumnName("category_name")
                .HasMaxLength(100)
                .IsRequired();
            //builder.HasData(new[]
            //{
            //    new CategoryEntity
            //    {
            //        Id = 1,
            //        CategoryName = "Cat",
            //    }
            //});


        }
    }
}
