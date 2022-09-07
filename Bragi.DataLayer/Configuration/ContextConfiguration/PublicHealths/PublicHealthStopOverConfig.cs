using Bragi.DataLayer.Models.PublicHealths;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.PublicHealths
{
    public class PublicHealthStopOverConfig: IEntityTypeConfiguration<PublicHealthStopOver>
    {
        public void Configure(EntityTypeBuilder<PublicHealthStopOver> builder)
        {
            builder.HasOne(x => x.PublicHealth).WithMany(x => x.PublicHealthStopOvers)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Country).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
