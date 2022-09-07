using System;
using Bragi.DataLayer.Models.Cities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Cities
{
    public class CitiesConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(500);
            builder.Property(x => x.Iso2CountryCode).HasMaxLength(20);
            builder.Property(x => x.Latitude).HasMaxLength(100);
            builder.Property(x => x.Longitude).HasMaxLength(100);
            builder.Property(x => x.State).HasMaxLength(350);
            builder.Property(x => x.StateCode).HasMaxLength(100);
            //builder.Property(x => x.CreationDate).HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
        }
    }
}
