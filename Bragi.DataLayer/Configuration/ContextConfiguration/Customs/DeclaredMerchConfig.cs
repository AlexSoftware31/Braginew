using Bragi.DataLayer.Models.Customs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Customs
{
    public class DeclaredMerchConfig: IEntityTypeConfiguration<DeclaredMerch>
    {
        public void Configure(EntityTypeBuilder<DeclaredMerch> builder)
        {
            builder.HasOne(x => x.CustomsInformation).WithMany(x => x.DeclaredMerchs);
            builder.Property(x => x.Description).HasMaxLength(600);
            builder.HasQueryFilter(x => !x.IsDeleted);
            builder.Property(x => x.DollarValue).HasColumnType("decimal(18,6)");

        }
    }
}
