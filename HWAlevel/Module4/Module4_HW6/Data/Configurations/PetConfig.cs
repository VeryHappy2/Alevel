using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW4.Data.Entities;

namespace Module4_HW4.Data.Configurations
{
    public sealed class PetConfig : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(x => x.CategoryId)
                .HasColumnName("category_id")
                .IsRequired();
            builder
                .Property(c => c.Id)
                .HasColumnName("id");
            builder
                .Property(x => x.age)
                .HasMaxLength(250)
                .IsRequired();
            builder
                .Property(x => x.Description)
                .HasMaxLength(5000);
            builder
                .HasOne(b => b.Breeds)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.BreedId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .HasOne(b => b.Category)
                .WithMany(p => p.Pets)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            builder
               .HasOne(b => b.Locations)
               .WithMany(p => p.Pets)
               .HasForeignKey(x => x.LocationId)
               .OnDelete(DeleteBehavior.NoAction);

            //builder.HasData(new[]
            //{
            //    new PetEntity
            //    {
            //        Name = "Barsik",
            //        Id = 1,
            //        BreedId = 1,
            //        CategoryId = 1,
            //        LocationId = 1,
            //        ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fkitipes.com.ua%2Fru%2Farticles%2Fshotlandskyy_kit_doglyad_kharakter_i_osoblyvosti_porody%2F&psig=AOvVaw0NcMcmak_rFncmEpI0PGa4&ust=1704102710291000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCKiszLmzuYMDFQAAAAAdAAAAABAD",
            //        age = 3,
            //        Description = "e"
            //    }
            //});
        }
    }
}
