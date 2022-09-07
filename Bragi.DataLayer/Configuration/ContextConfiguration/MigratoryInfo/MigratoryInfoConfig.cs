using Bragi.DataLayer.Models.MigratoryInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bragi.DataLayer.Configuration.ContextConfiguration.MigratoryInfo
{
    public class MigratoryInfoConfig:IEntityTypeConfiguration<MigratoryInformation>
    {
        public void Configure(EntityTypeBuilder<MigratoryInformation> builder)
        {
            builder.Property(x => x.Names)
                .HasMaxLength(150);
            builder.Property(x => x.LastNames)
                .HasMaxLength(150);
            builder.Property(x => x.DocumentIdNumber).HasMaxLength(25);
            builder.Property(x => x.Gender);
                
            builder.Property(x => x.Nationality)
                .HasMaxLength(10);
            builder.Property(x => x.BirthPlace)
                .HasMaxLength(100);
            builder.Property(x => x.PassportNumber)
                .HasMaxLength(11);
            builder.Property(x => x.OriginPort).HasMaxLength(100);
            builder.Property(x => x.OriginFlightNumber).HasMaxLength(100);
            builder.Property(x => x.EmbarkationPort)
                .HasMaxLength(100);
            builder.Property(x => x.EmbarcationFlightNumber)
                .HasMaxLength(50);
            builder.Property(x => x.EmbarcationDate);
            builder.Property(x => x.DisembarkationPort).HasMaxLength(100);
            builder.Property(x => x.TransportationCompany).HasMaxLength(100);
            builder.Property(x => x.ConfirmationNumber).HasMaxLength(10);
            builder.Property(x => x.ResidenceNumber).HasMaxLength(12);
            builder.Property(x => x.Email).HasMaxLength(40);
            builder.Property(x => x.GeoCode).HasMaxLength(40);
            builder.Property(x => x.DaysOfStaying);
            builder.Property(x => x.SpecificFlightMotive).HasMaxLength(200);
            builder.HasOne(x => x.MaritalStatus);
            builder.HasOne(x => x.FlightMotive);
            builder.HasOne(x => x.Application).WithMany(x => x.MigratoryInformations).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.CustomsInformation).WithOne(x => x.MigratoryInformation).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.PublicHealth).WithOne(x => x.MigratoryInformation).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.TaxReturnInfo).WithOne(x => x.MigratoryInformation).OnDelete(DeleteBehavior.NoAction);
            builder.HasQueryFilter(x => !x.IsDeleted);           
        }
    }
}