using Bragi.DataLayer.Models.PublicHealths;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.PublicHealths
{
    public class PublicHealthCountriesConfig: IEntityTypeConfiguration<PublicHealthCountries>
    {
        public void Configure(EntityTypeBuilder<PublicHealthCountries> builder)
        {
            builder.HasOne(x => x.PublicHealth).WithMany(x => x.PublicHealthCountries)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Country).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
