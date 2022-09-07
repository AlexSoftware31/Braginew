using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.GenericInformation
{
    public class GenericInfoConfig:IEntityTypeConfiguration<Models.GenericInformations.GenericInformation>
    {
        public void Configure(EntityTypeBuilder<Models.GenericInformations.GenericInformation> builder)
        {
            builder.Property(x => x.CityOfResidence).HasMaxLength(150);
            builder.Property(x => x.State).HasMaxLength(150);
            builder.Property(x => x.CountryResidence).HasMaxLength(150);
            builder.Property(x => x.ZipCode).HasMaxLength(150);
            builder.Property(x => x.PermanentResidenceAdress).HasMaxLength(200);
            builder.HasQueryFilter(x => !x.IsDeleted);
        }
    }
}