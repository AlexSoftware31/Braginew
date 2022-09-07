using System;
using Bragi.DataLayer.Configuration.ContextConfiguration.Agencies;
using Bragi.DataLayer.Configuration.ContextConfiguration.Applications;
using Bragi.DataLayer.Configuration.ContextConfiguration.Cities;
using Bragi.DataLayer.Configuration.ContextConfiguration.Country;
using Bragi.DataLayer.Configuration.ContextConfiguration.Currencies;
using Bragi.DataLayer.Configuration.ContextConfiguration.Customs;
using Bragi.DataLayer.Configuration.ContextConfiguration.FlightMotive;
using Bragi.DataLayer.Configuration.ContextConfiguration.GenericInformation;
using Bragi.DataLayer.Configuration.ContextConfiguration.GeoCode;
using Bragi.DataLayer.Configuration.ContextConfiguration.Hotels;
using Bragi.DataLayer.Configuration.ContextConfiguration.MigratoryInfo;
using Bragi.DataLayer.Configuration.ContextConfiguration.Ocupations;
using Bragi.DataLayer.Configuration.ContextConfiguration.PublicHealths;
using Bragi.DataLayer.Configuration.ContextConfiguration.RequestLogs;
using Bragi.DataLayer.Configuration.ContextConfiguration.TaxReturnInfos;
using Bragi.DataLayer.Configuration.ContextConfiguration.TransportantionMethod;
using Bragi.DataLayer.Models.Agencies;
using Bragi.DataLayer.Models.Airlines;
using Bragi.DataLayer.Models.Applications;
using Bragi.DataLayer.Models.ApplicationStatus;
using Bragi.DataLayer.Models.Cities;
using Bragi.DataLayer.Models.Countries;
using Bragi.DataLayer.Models.Currencies;
using Bragi.DataLayer.Models.ETickets;
using Bragi.DataLayer.Models.FlightMotives;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.Models.Hotels;
using Bragi.DataLayer.Models.Languages;
using Bragi.DataLayer.Models.MigratoryInfo;
using Bragi.DataLayer.Models.Ocupations;
using Bragi.DataLayer.Models.Ports;
using Bragi.DataLayer.Models.PublicHealths;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.Models.RequestLogs;
using Bragi.DataLayer.Models.Steps;
using Bragi.DataLayer.Models.TaxReturnInfos;
using Bragi.DataLayer.Models.Transportation;
using Bragi.DataLayer.Models.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bragi.DataLayer.Context
{
    public class ProyectDbContext : IdentityDbContext<User>
    {
        public ProyectDbContext(DbContextOptions<ProyectDbContext> context) : base(context)
        {
           //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
#if DEBUG
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
#endif

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AgencysConfig());
            modelBuilder.ApplyConfiguration(new FlightMotiveConfig());
            modelBuilder.ApplyConfiguration(new HotelConfig());
            modelBuilder.ApplyConfiguration(new MigratoryInfoConfig());
            modelBuilder.ApplyConfiguration(new OcupationConfig());
            modelBuilder.ApplyConfiguration(new GenericInfoConfig());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationsConfig());
            modelBuilder.ApplyConfiguration(new StatusConfig());
            modelBuilder.ApplyConfiguration(new CurrenciesConfig());
            modelBuilder.ApplyConfiguration(new CustomsConfig());
            modelBuilder.ApplyConfiguration(new DeclaredMerchConfig());
            modelBuilder.ApplyConfiguration(new PublicHealthConfig());
            modelBuilder.ApplyConfiguration(new ProvincesConfig());
            modelBuilder.ApplyConfiguration(new MunicipalityConfig());
            modelBuilder.ApplyConfiguration(new SectorConfig());
            modelBuilder.ApplyConfiguration(new PublicHealthCountriesConfig());
            modelBuilder.ApplyConfiguration(new PublicHealthStopOverConfig());
            modelBuilder.ApplyConfiguration(new RequestLogConfig());
            modelBuilder.ApplyConfiguration(new CitiesConfiguration());
            modelBuilder.ApplyConfiguration(new TransportationConfig());
            modelBuilder.ApplyConfiguration(new TaxReturnInfoConfig());
        }

        public DbSet<Agency> Agencies { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<FlightMotive> FlightMotives { get; set; }
        public DbSet<MigratoryInformation> MigratoryInformations { get; set; }
        public DbSet<GenericInformation> GenericInformations { get; set; }
        public DbSet<Ocupation> Ocupations { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionResponse> QuestionResponses { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Provinces> Provinces { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Sectors> Sectors { get; set; }
        public DbSet<TransportationMethod> Transportation { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<ApplicationToken> ApplicationTokens { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<PublicHealth> PublicHealths { get; set; }
        public DbSet<PublicHealthStopOver> PublicHealthStopOvers { get; set; }
        public DbSet<PublicHealthCountries> PublicHealthCountries { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Eticket> Etickets { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Port> Ports { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<TaxReturnInfo> TaxReturnInfos { get; set; }
    }
}
