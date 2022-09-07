using Bragi.DataLayer.Models.ApplicationStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Applications
{
    class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(25);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
