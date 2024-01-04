using Microsoft.EntityFrameworkCore;
using Module4_HW4.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Module4_HW4.Configurations
{
    public sealed class LocationConfig : IEntityTypeConfiguration<Location>
    {        
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.LocationName)
                .HasColumnName("location_name")
                .HasMaxLength(100);
            builder
                .Property(x => x.Id)
                .ValueGeneratedNever();

            builder.HasData(new[]
            {
                new Location
                {
                    Id = 0,
                    LocationName = "Europe"
                }

            });

        }
    }
}
