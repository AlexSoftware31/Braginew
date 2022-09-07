using Bragi.DataLayer.Models.Currencies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Currencies
{
    public class CurrenciesConfig : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(75);
            builder.Property(x => x.Code).HasMaxLength(5);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
