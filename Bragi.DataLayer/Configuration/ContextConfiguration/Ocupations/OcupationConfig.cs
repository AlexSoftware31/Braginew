using Bragi.DataLayer.Models.Ocupations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Ocupations
{
    public class OcupationConfig:IEntityTypeConfiguration<Ocupation>
    {
        public void Configure(EntityTypeBuilder<Ocupation> builder)
        {
            builder.Property(x => x.ShortName).HasMaxLength(100);
            builder.HasQueryFilter(x => !x.IsDeleted);

        }
    }
}