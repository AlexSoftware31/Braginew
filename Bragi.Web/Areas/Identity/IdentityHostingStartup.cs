using Bragi.DataLayer.Context;
using Bragi.DataLayer.Models.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Bragi.Web.Areas.Identity.IdentityHostingStartup))]
namespace Bragi.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ProyectDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MigratoryTickets")));

                services
                    .AddIdentity<User,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<ProyectDbContext>();
            });
        }
    }
}