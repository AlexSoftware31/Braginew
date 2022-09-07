using AutoMapper;
using Bragi.BussinessLayer.Interfaces.Agencies;
using Bragi.BussinessLayer.Interfaces.Airlines;
using Bragi.BussinessLayer.Interfaces.Applications;
using Bragi.BussinessLayer.Interfaces.Cities;
using Bragi.BussinessLayer.Interfaces.Countries;
using Bragi.BussinessLayer.Interfaces.Currencies;
using Bragi.BussinessLayer.Interfaces.Customs;
using Bragi.BussinessLayer.Interfaces.ETickets;
using Bragi.BussinessLayer.Interfaces.FlightMotives;
using Bragi.BussinessLayer.Interfaces.GeoCodes;
using Bragi.BussinessLayer.Interfaces.Hotels;
using Bragi.BussinessLayer.Interfaces.Imi;
using Bragi.BussinessLayer.Interfaces.Jwt;
using Bragi.BussinessLayer.Interfaces.Languages;
using Bragi.BussinessLayer.Interfaces.MigratoryInfo;
using Bragi.BussinessLayer.Interfaces.Ocupations;
using Bragi.BussinessLayer.Interfaces.PersonalInformation;
using Bragi.BussinessLayer.Interfaces.Ports;
using Bragi.BussinessLayer.Interfaces.PublicHealths;
using Bragi.BussinessLayer.Interfaces.Questions;
using Bragi.BussinessLayer.Interfaces.RequestLogs;
using Bragi.BussinessLayer.Interfaces.Steps;
using Bragi.BussinessLayer.Interfaces.Transportation;
using Bragi.BussinessLayer.Services.Agencies;
using Bragi.BussinessLayer.Services.Airlines;
using Bragi.BussinessLayer.Services.Applications;
using Bragi.BussinessLayer.Services.Cities;
using Bragi.BussinessLayer.Services.Countries;
using Bragi.BussinessLayer.Services.Currencies;
using Bragi.BussinessLayer.Services.Customs;
using Bragi.BussinessLayer.Services.ETickets;
using Bragi.BussinessLayer.Services.FlightMotives;
using Bragi.BussinessLayer.Services.GenericInformations;
using Bragi.BussinessLayer.Services.GeoCodes;
using Bragi.BussinessLayer.Services.Hotels;
using Bragi.BussinessLayer.Services.Imi;
using Bragi.BussinessLayer.Services.Jwt;
using Bragi.BussinessLayer.Services.Languages;
using Bragi.BussinessLayer.Services.MigratoryInfo;
using Bragi.BussinessLayer.Services.Ocupations;
using Bragi.BussinessLayer.Services.Ports;
using Bragi.BussinessLayer.Services.PublicHealths;
using Bragi.BussinessLayer.Services.Questions;
using Bragi.BussinessLayer.Services.RequestLogs;
using Bragi.BussinessLayer.Services.Steps;
using Bragi.BussinessLayer.Services.Transportation;
using Bragi.DataLayer;
using Bragi.DataLayer.Configuration.LanguageModel;
using Bragi.DataLayer.Configuration.OptionsModel;
using Bragi.DataLayer.Context;
using Bragi.DataLayer.Validators.GenericInformation;
using Bragi.DataLayer.Validators.MigratoryInfo;
using Bragi.DataLayer.Validators.PublicHealth;
using Bragi.DataLayer.ViewModels.Airlines;
using Bragi.DataLayer.ViewModels.Cities;
using Bragi.DataLayer.ViewModels.Countries;
using Bragi.DataLayer.ViewModels.GenericInformations;
using Bragi.DataLayer.ViewModels.GeoCodes;
using Bragi.DataLayer.ViewModels.Hotels;
using Bragi.DataLayer.ViewModels.MigratoryInfo;
using Bragi.DataLayer.ViewModels.PublicHealths;
using Bragi.Web.Configurations.Middlewares;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bragi.Web.Configurations.Extensions.Startup
{
    public static class StartupExtension
    {
        public static void ConfigureDbContext(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<ProyectDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("MigratoryTickets"));
            }, ServiceLifetime.Transient);
        }

        public static void ConfigureImiDbContext(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<ImiDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("Imi"));
            }, ServiceLifetime.Transient);
        }

        public static void ConfigureAutoMapper(this IServiceCollection service)
        {
            var config = new MapperConfiguration(cfg =>
            {
                var mainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(c => c.GetName().Name == "Bragi.DataLayer");
                cfg.AddMaps(mainAssembly);
                cfg.AllowNullCollections = true;
            });
            var mapper = config.CreateMapper();
            service.AddSingleton(mapper);
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IHotelService, HotelService>();
            services.AddTransient<ICountriesService, CountriesService>();
            services.AddTransient<IOcupationsService, OcupationsService>();
            services.AddTransient<IAgencyService, AgencyService>();
            services.AddTransient<IFlightMotivesService, FlightMotivesService>();
            services.AddTransient<ILanguagesService, LanguageService>();
            services.AddTransient<IQuestionsService, QuestionsService>();
            services.AddTransient<IQuestionResponseService, QuestionResponseService>();
            services.AddTransient<IApplicationsService, ApplicationsService>();
            services.AddTransient<IMaritalStatusService, MaritalStatusService>();
            services.AddTransient<IGenericInformationService, GenericInformationService>();
            services.AddTransient<ITransportationService, TransportationService>();
            services.AddTransient<IMigratoryInfoService, MigratoryInfoService>();
            services.AddTransient<ICustomsService, CustomsService>();
            services.AddTransient<IDeclaredMerchService, DeclaredMerchService>();
            services.AddTransient<IProvinceService, ProvinceService>();
            services.AddTransient<IMunicipalityService, MunicipalityService>();
            services.AddTransient<ISectorsService, SectorsService>();
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<IApplicationTokenService, ApplicationTokenService>();
            services.AddTransient<IPublicHealthService, PublicHealthService>();
            services.AddTransient<IPublicHealthStopOverService, PublicHealthStopOverService>();
            services.AddTransient<IPublicHealthCountriesService, PublicHealthCountriesService>();
            services.AddTransient<IPublicHealthValidatorService, PublicHealthValidatorService>();
            services.AddTransient<IStepsService, StepsService>();
            services.AddTransient<IEticketsService, ETicketService>();
            services.AddTransient<IAirlineService, AirlineService>();
            services.AddTransient<IPortsService, PortService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IRequestLogService, RequestLogService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddSingleton<IAppResource, SharedResources>();
        }

        public static void InjectExternalServices(this IServiceCollection services)
        {
            services.AddTransient<IimiEticketService, ImiEticketService>();
        }

        public static void InjectValidators(this IServiceCollection services)
        {
            services.AddTransient<IValidator<GenericInformationViewModel>, GenericInformationViewModelValidator>();
            services.AddTransient<IValidator<MigratoryInformationViewModel>, MigratoryInformationViewModelValidator>();
            services.AddTransient<IValidator<PublicHealthViewModel>, PublicHealthViewModelValidator>();
        }
        public static void ConfigureCultures(this IServiceCollection service, IConfiguration config)
        {
            service.Configure<List<SupportedCultures>>(config.GetSection("SupportedCultures"));
        }
        public static void ConfigureCaptcha(this IServiceCollection service, IConfiguration config)
        {
            service.Configure<CaptchaSecret>(config.GetSection("CaptchaSecret"));
        }
        public static void ConfigurePdfGeneration(this IServiceCollection service, IConfiguration config)
        {
            service.Configure<GeneratePdfUrl>(config.GetSection("GeneratePdfUrl"));
        }

        public static void ConfigureDgaRoutes(this IServiceCollection service, IConfiguration config)
        {
            service.Configure<DgaRouteConfig>(config.GetSection("DgaRouteConfig"));
        }

        public static void ConfigureGlobalization(this IServiceCollection service, IConfiguration config)
        {
            service.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            var supportedCultures = new string[] { "es-ES", "en-US", "ru-RU", "it-IT", "pt-PT", "de-DE","fr-FR" };
            service.Configure<RequestLocalizationOptions>(options =>
            {
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });
        }

        public static void SetJwtOptions(this IServiceCollection service, IConfiguration configuration) =>
            service.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

        public static void AuthJwtConfig(this IServiceCollection services, IConfiguration configuration)
        {


            services
                .AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = "/Identity/Account";
                    options.AccessDeniedPath = "/Identity/Manage";
                })
                //.AddAuthentication(opt =>
                //    {
                //        opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //        opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //    })
                .AddJwtBearer(options =>
            {
#if DEBUG
                options.RequireHttpsMetadata = false;

#endif
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtConfig:ValidIssuer"],
                    ValidAudience = configuration["JwtConfig:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SecretKey"])),
                    ClockSkew = TimeSpan.FromMinutes(Convert.ToInt32(configuration["JwtConfig:ExpirationMinutes"])),
                    RequireExpirationTime = true
                };
            });
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Airlines", policy => policy.RequireRole("QRConsulting", "Administrator"));

                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

        }

        public static void CorsService(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("SpecificOrigins", builder =>
                    {
                        builder.WithOrigins("https://eticket.migracion.gob.do");
                    });
            });

        }

        public static void ConfigureCors(this IApplicationBuilder app)
        {
            app.UseCors("SpecificOrigins");
        }

        public static void AppGlobalization(this IApplicationBuilder app)
        {
            var supportedCultures = new string[] { "es-ES", "en-US", "ru-RU", "it-IT", "pt-PT", "de-DE", "fr-FR" };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);
            app.UseRequestLocalization(localizationOptions);
        }


        public static async Task ImplementCache(this IApplicationBuilder app, IMemoryCache memoryCache)
        {
            using var scope = ServiceProviderServiceExtensions.GetRequiredService<IServiceScopeFactory>(app.ApplicationServices).CreateScope();
            var municipalityService = scope.ServiceProvider.GetService<IMunicipalityService>();
            var provinceService = scope.ServiceProvider.GetService<IProvinceService>();
            var sectorsService = scope.ServiceProvider.GetService<ISectorsService>();
            var countriesService = scope.ServiceProvider.GetService<ICountriesService>();
            var airlinesService = scope.ServiceProvider.GetService<IAirlineService>();
            var hotelsService = scope.ServiceProvider.GetService<IHotelService>();
            var citiesService = scope.ServiceProvider.GetService<ICitiesService>();


            if (!memoryCache.TryGetValue("Provinces", out IEnumerable<ProvincesViewModel> _))
            {
               
                var result = await provinceService.GetAll();
                memoryCache.Set("Provinces", result);
            }
            if (!memoryCache.TryGetValue("Municipalities", out IEnumerable<MunicipalityViewModel> _))
            {
                var result = await municipalityService.GetAll();
                memoryCache.Set("Municipalities",result);
            }
            if (!memoryCache.TryGetValue("Sectors", out IEnumerable<SectorsViewModel> _))
            {
                var result = await sectorsService.GetAll();

                memoryCache.Set("Sectors", result);
            }
            if (!memoryCache.TryGetValue("Airlines", out IEnumerable<AirlineViewModel> _))
            {
                var result = await airlinesService.GetAll();
                memoryCache.Set("Airlines", result.OrderBy(x => x.Name));
            }
            if (!memoryCache.TryGetValue("Countries", out IEnumerable<CountryViewModel> _))
            {
                var result = await countriesService.GetAll();
                memoryCache.Set("Countries", result.OrderBy(x => x.Name));
            }
            if (!memoryCache.TryGetValue("Hotels", out IEnumerable<HotelViewModel> _))
            {
                var result = await hotelsService.GetAll();
                memoryCache.Set("Hotels", result);
            }
            if (!memoryCache.TryGetValue("Cities", out IEnumerable<CityViewModel> _))
            {
                var result = await citiesService.GetAll();
                memoryCache.Set("Cities", result.OrderBy(x => x.Name));
            }
        }

        public static IServiceCollection AddSerilogServices(this IServiceCollection services, IConfiguration configuration)
        {
            var useLog = Convert.ToBoolean(configuration["SerilogConfig:UseLog"]);

            if (useLog)
            {
                Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration, "SerilogConfig")
                .CreateLogger();
                AppDomain.CurrentDomain.ProcessExit += (_, __) => Log.CloseAndFlush();
            }

            return services.AddSingleton(Log.Logger);
        }

        public static IApplicationBuilder UseRequestLogger(this IApplicationBuilder app, IConfiguration configuration)
        {
            var useLog = Convert.ToBoolean(configuration["SerilogConfig:UseLog"]);

            var staticFileExtensions = new List<string>
                {
                    ".css", ".js", ".png", ".ico",
                    ".min", ".map", ".jpg"
                };
            return app.UseWhen(context => (useLog && !staticFileExtensions.Any(ext => context.Request.Path.Value.EndsWith(ext))),
                appBuilder =>
                {
                    appBuilder.UseMiddleware<SerilogRequestLogger>();
                });
        }
    }
}
