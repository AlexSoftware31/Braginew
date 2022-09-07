using Bragi.DataLayer.Models.ETickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.Etickets
{
    public class EticketsConfig : IEntityTypeConfiguration<Eticket>
    {
        public void Configure(EntityTypeBuilder<Eticket> builder)
        {
            builder.Property(x => x.PrincipalName).HasMaxLength(150);
            builder.Property(x => x.Nationality).HasMaxLength(5);
            builder.Property(x => x.InOut).HasMaxLength(20);
            builder.Property(x => x.Passport).HasMaxLength(20);
            
        }
    }
}
