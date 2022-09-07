using Bragi.DataLayer.Configuration.DataSeed;
using Bragi.Web.Configurations.Extensions.Startup;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SharedResource = Bragi.DataLayer.SharedResource;

namespace Bragi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHostEnvironment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddLocalization(opt => { opt.ResourcesPath = "Resources";});
            services.AddControllersWithViews()
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(SharedResource));
                }).AddFluentValidation();
            services.AddMemoryCache();
            services.ConfigureDbContext(Configuration);
            services.ConfigureImiDbContext(Configuration);
            services.ConfigureAutoMapper();
            services.InjectServices();
            services.InjectExternalServices();
            services.CorsService();
            services.ConfigureCultures(Configuration);
            services.ConfigureGlobalization(Configuration);
            services.ConfigureCaptcha(Configuration);
            services.ConfigurePdfGeneration(Configuration);
            services.ConfigureDgaRoutes(Configuration);
            services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Account", "Airlines");
            });
            services.SetJwtOptions(Configuration);
            services.AuthJwtConfig(Configuration);
            services.AddDataProtection();
            services.InjectValidators();
            services.AddSerilogServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache memoryCache)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            
            app.UseAuthorization();
            DataSeeding.Seed(app);
            app.AppGlobalization();
            app.ConfigureCors();
            //Task.Run(async () => await app.ImplementCache(memoryCache));
            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseRequestLogger(Configuration);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                
            });

            
        }
    }
}
