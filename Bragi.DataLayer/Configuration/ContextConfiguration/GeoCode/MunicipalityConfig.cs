using Bragi.DataLayer.Models.GeoCodes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.GeoCode
{
    public class MunicipalityConfig:IEntityTypeConfiguration<Municipality>
    {
        public void Configure(EntityTypeBuilder<Municipality> builder)
        {
            //builder.Property(x => x.GeoCode).HasMaxLength(40);
            builder.Property(x => x.MacroRegion).HasMaxLength(40);
            builder.Property(x => x.Region).HasMaxLength(40);
            builder.Property(x => x.Province).HasMaxLength(40);
            builder.Property(x => x.ToponomyName).HasMaxLength(350);
            builder.Property(x => x.Municipalities).HasMaxLength(40);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
