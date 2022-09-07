using Bragi.DataLayer.Models.Hotels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Hotels
{
    public class HotelConfig:IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.ShortName).HasMaxLength(35);
            builder.Property(x => x.Coordinates).HasMaxLength(100);
            builder.Property(x => x.GeoCode).HasMaxLength(60);
            builder.Property(x => x.SocialReason).HasMaxLength(150);
            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}