using Bragi.DataLayer.Models.Customs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Customs
{
    public class CustomsConfig : IEntityTypeConfiguration<CustomsInformation>
    {
        public void Configure(EntityTypeBuilder<CustomsInformation> builder)
        {
            builder.Property(x => x.Ammount).HasColumnType("decimal(18,6)");
            builder.Property(x => x.ValueOfMerchandise).HasColumnType("decimal(18,6)");
            builder.HasOne(x => x.MigratoryInformation).WithOne(x => x.CustomsInformation).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Application).WithMany(x=> x.CustomsInformations).OnDelete(DeleteBehavior.NoAction); ;
            builder.HasOne(x => x.Currency);
            builder.HasMany(x => x.DeclaredMerchs).WithOne(x => x.CustomsInformation).OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
