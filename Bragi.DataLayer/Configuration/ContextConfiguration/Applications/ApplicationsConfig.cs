using Bragi.DataLayer.Models.Applications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Applications
{
    public class ApplicationsConfig:IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.Companions).HasDefaultValue(0);
            builder.Property(x => x.AssistantName).HasMaxLength(300);
            builder.Property(x => x.AssistantRelation).HasMaxLength(100);
            builder.HasOne(x => x.Status);
            builder.HasOne(x => x.GenericInformation).WithOne(x => x.Application).OnDelete(DeleteBehavior.NoAction); 
            builder.HasMany(x => x.MigratoryInformations).WithOne(x => x.Application).OnDelete(DeleteBehavior.NoAction); 
            builder.HasMany(x => x.PublicHealths).WithOne(x => x.Application).OnDelete(DeleteBehavior.NoAction); 
            builder.HasMany(x => x.CustomsInformations).WithOne(x => x.Application).OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}