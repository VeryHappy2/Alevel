using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4_HW4.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(c => c.Id)
                .ValueGeneratedNever();
            builder
                .Property(c => c.CategoryName)
                .HasColumnName("category_name")
                .HasMaxLength(100);

            builder.HasData(new[]
            {
                new Category
                {
                    CategoryName = "Cats",
                    Id = 0
                },
                new Category
                {
                    CategoryName = null,
                    Id = 1,
                }
            }); 
                
           
        }
    }
}
