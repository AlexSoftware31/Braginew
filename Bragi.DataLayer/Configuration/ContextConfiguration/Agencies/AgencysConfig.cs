using Bragi.DataLayer.Models.Agencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Agencies
{
    public class AgencysConfig:IEntityTypeConfiguration<Agency>
    {
        public void Configure(EntityTypeBuilder<Agency> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150);
            builder.Property(x => x.ShortName).HasMaxLength(35);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}