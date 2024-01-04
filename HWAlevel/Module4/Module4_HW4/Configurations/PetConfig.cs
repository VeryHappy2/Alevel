using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW4.Models;

namespace Module4_HW4.Configurations
{
    public sealed class PetConfig : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(100);
            builder
                .Property(x => x.CategoryId)
                .HasColumnName("category_id");
            builder
                .Property (x => x.Id)
                .ValueGeneratedNever();
            builder
                .Property (x => x.age)
                .HasMaxLength (250);
            builder
                .Property(x => x.Description)
                .HasMaxLength(5000);

            builder.HasData(new[]
            {
                new Pet
                {
                    Name = "Barsik",
                    Id = 0,
                    BreedId = 0,
                    CategoryId = 0,
                    LocationId = 0,
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fkitipes.com.ua%2Fru%2Farticles%2Fshotlandskyy_kit_doglyad_kharakter_i_osoblyvosti_porody%2F&psig=AOvVaw0NcMcmak_rFncmEpI0PGa4&ust=1704102710291000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCKiszLmzuYMDFQAAAAAdAAAAABAD",
                    age = 3,
                    Description = null
                }
            });
        }
    }
}
