using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Country
{
    public class CountryConfiguration : IEntityTypeConfiguration<Models.Countries.Country>
    {
        public void Configure(EntityTypeBuilder<Models.Countries.Country> builder)
        {
            builder.Property(x => x.Iso3).HasMaxLength(4);
            builder.Property(x => x.Iso2).HasMaxLength(3);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.OfficialName).HasMaxLength(100);
            builder.Property(x => x.Latitude).HasMaxLength(100);
            builder.Property(x => x.Logitude).HasMaxLength(100);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
