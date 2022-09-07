using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Agencies;
using Bragi.DataLayer.Models.ApplicationStatus;
using Bragi.DataLayer.Models.Countries;
using Bragi.DataLayer.Models.Currencies;
using Bragi.DataLayer.Models.Enums;
using Bragi.DataLayer.Models.FlightMotives;
using Bragi.DataLayer.Models.GenericInformations;
using Bragi.DataLayer.Models.GeoCodes;
using Bragi.DataLayer.Models.Hotels;
using Bragi.DataLayer.Models.Languages;
using Bragi.DataLayer.Models.Ocupations;
using Bragi.DataLayer.Models.Questions;
using Bragi.DataLayer.Models.Steps;
using Bragi.DataLayer.Models.Transportation;
using Bragi.DataLayer.Models.Users;
using Bragi.DataLayer.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bragi.DataLayer.Models.Airlines;
using Bragi.DataLayer.Models.Ports;

namespace Bragi.DataLayer.Configuration.DataSeed
{
    public static class DataSeeding
    {
        public static async void Seed(IApplicationBuilder appBuilder)
        {
            using var scope = ServiceProviderServiceExtensions.GetRequiredService<IServiceScopeFactory>(appBuilder.ApplicationServices).CreateScope();
            var context = scope.ServiceProvider.GetService<ProyectDbContext>();
            var usr = scope.ServiceProvider.GetService<UserManager<User>>();
            var role = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            if (!context.Agencies.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Agencies/Agencies.json");
                var list = JsonConvert.DeserializeObject<List<Agency>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.QuestionTypes.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Questions/QuestionType.json");
                var list = JsonConvert.DeserializeObject<List<QuestionType>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.Countries.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Countries/countries.json");
                var countries = JsonConvert.DeserializeObject<List<Country>>(stream);
                countries.ForEach(x => x.Id = 0);
                await context.AddRangeAsync(countries);
                await context.SaveChangesAsync();
            }

            if (!context.Languages.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Languages/Languages.json");
                var list = JsonConvert.DeserializeObject<List<Language>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();

            }

            if (!context.FlightMotives.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Motives/Motives.json");
                var list = JsonConvert.DeserializeObject<List<FlightMotive>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.Ocupations.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Ocupations/Ocupations.json");
                var list = JsonConvert.DeserializeObject<List<Ocupation>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();

            }

            if (!context.MaritalStatuses.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/MaritalStatus/MaritalStatus.json");
                var list = JsonConvert.DeserializeObject<List<MaritalStatus>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.Hotels.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Hotels/Hotels.json");
                var list = JsonConvert.DeserializeObject<List<Hotel>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.Questions.Any())
            {
                var seqStream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Questions/Security.json");
                var ph = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Questions/PublicHealth.json");
                var securityQuestions = JsonConvert.DeserializeObject<List<Question>>(seqStream);
                var publicH = JsonConvert.DeserializeObject<List<Question>>(ph);
                await context.AddRangeAsync(publicH);
                await context.AddRangeAsync(securityQuestions);
                await context.SaveChangesAsync();
            }

            if (!context.Provinces.Any())
            {
                using var stream = new StreamReader("./../Bragi.DataLayer/Assets/GeoCodes/Provinces.json");
                var listStream = await stream.ReadToEndAsync();
                var list = JsonConvert.DeserializeObject<List<Provinces>>(listStream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.Municipalities.Any())
            {
                using var stream = new StreamReader("./../Bragi.DataLayer/Assets/GeoCodes/Municipality.json");
                var listStream = await stream.ReadToEndAsync();
                var list = JsonConvert.DeserializeObject<List<Municipality>>(listStream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.Sectors.Any())
            {
                using var stream = new StreamReader("./../Bragi.DataLayer/Assets/GeoCodes/Sectors.json");
                var listStream = await stream.ReadToEndAsync();
                var list = JsonConvert.DeserializeObject<List<Sectors>>(listStream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            if (!context.Transportation.Any())
            {
                var tm = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Transportation/TransportationMethod.json");
                var list = JsonConvert.DeserializeObject<List<TransportationMethod>>(tm);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            if (!context.Currencies.Any())
            {
                var tm = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Currencies/Currencies.json");
                var list = JsonConvert.DeserializeObject<List<Currency>>(tm);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            if (!context.Status.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Status/Status.json");
                var list = JsonConvert.DeserializeObject<List<Status>>(stream);
                list.ForEach(item =>
                {
                    item.StatusEnum = (StatusEnum)Enum.Parse(typeof(StatusEnum), item.Name);
                    item.CreatedBy = "DataSeed";
                });
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!context.Steps.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Steps/Steps.json");
                var list = JsonConvert.DeserializeObject<List<Step>>(stream);
                list.ForEach(item =>
                {
                    item.StepsEnum = (StepsEnum)Enum.Parse(typeof(StepsEnum), item.Name);
                    item.CreatedBy = "DataSeed";
                });
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            if (!context.UserTypes.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/UserTypes/UserTypes.json");
                var list = JsonConvert.DeserializeObject<List<UserType>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            if (!context.Ports.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/DominicanPorts/DominicanPorts.json");
                var list = JsonConvert.DeserializeObject<List<Port>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }

            if (!role.Roles.Any())
            {
                try
                {
                    var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Roles/Roles.json");
                    var list = JsonConvert.DeserializeObject<List<IdentityRole>>(stream);
                    foreach (var roles in list)
                    {
                        await role.CreateAsync(roles);
                    }

                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                
            }
            if (!context.Airlines.Any())
            {
                var stream = ClassUtils.GetFromJson("./../Bragi.DataLayer/Assets/Airlines/Airlines.json");
                var list = JsonConvert.DeserializeObject<List<Airline>>(stream);
                await context.AddRangeAsync(list);
                await context.SaveChangesAsync();
            }
            if (!context.Users.Any())
            {
               
            }
        }
    }


}
