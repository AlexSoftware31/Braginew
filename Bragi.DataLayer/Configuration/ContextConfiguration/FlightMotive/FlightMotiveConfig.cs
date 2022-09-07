using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.FlightMotive
{
    public class FlightMotiveConfig:IEntityTypeConfiguration<Models.FlightMotives.FlightMotive>
    {
        public void Configure(EntityTypeBuilder<Models.FlightMotives.FlightMotive> builder)
        {
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}