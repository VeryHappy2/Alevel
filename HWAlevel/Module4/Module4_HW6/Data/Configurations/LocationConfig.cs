using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4_HW4.Data.Entities;
using Module4_HW6.Data.Entities;

namespace Module4_HW4.Data.Configurations
{
    public sealed class LocationConfig : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.LocationName)
                .HasColumnName("location_name")
                .HasMaxLength(100)
                .IsRequired();
            builder
                .Property(c => c.Id)
                .HasColumnName("id");
            //builder.HasData(new[]
            //{
            //    new LocationEntity
            //    {
            //        Id = 1,
            //        LocationName = "Greate Britain",
            //    }
            //});
        }
    }
}
