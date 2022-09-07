using Bragi.DataLayer.Models.Transportation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.TransportantionMethod
{
    public class TransportationConfig : IEntityTypeConfiguration<TransportationMethod>
    {
        public void Configure(EntityTypeBuilder<TransportationMethod> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
