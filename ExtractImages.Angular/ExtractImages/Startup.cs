using AutoMapper;
using ExtractImages.Constants;
using ExtractImages.Mapper;
using ExtractImages.Middleware;
using ExtractImages.Services;
using ExtractImages.Services.Security;
using ExtractImages.SqlServer.Driver;
using ExtractImages.SqlServer.Driver.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MortgageHouse.Backend.SqlServerDriver;
using System.IO;

namespace ExtractImages
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        private void ConfigureDatabaseSetup()
        {
            if (!Directory.Exists(DbConstants.ImageDirectory))
                Directory.CreateDirectory(DbConstants.ImageDirectory);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabaseSetup();
            services.AddMvc(w => w.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //Services
            services.AddScoped<ImageCommonService>()
                .AddScoped<DatabaseServiceAccess>()
                .AddScoped<UserSecurity>();

            //Mapper
            services.AddScoped<IMapper>(c => new MapperConfiguration(c => c.AddProfile<ImageMapper>()).CreateMapper());

            //Repositories & Data Access
            services.AddDbContext<ContentDb>(builder => builder.UseSqlServer(DbConstants.DbConnectionString))
            .AddScoped<NewDataRepository>()
           .AddScoped<OldDataRepository>();

            //Gzip Compression
            //services.Configure<BrotliCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            //services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            //Angular Setup
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //services.AddCors(options =>
            //{
            //    options.AddPolicy(AppInformation.AppName,
            //    builder =>
            //    {
            //        builder.WithOrigins("http://localhost:4200")
            //                            .AllowAnyHeader()
            //                            .AllowAnyMethod()
            //                            .AllowCredentials();
            //    });
            //});

            //Services for Authentication
            //services.AddAuthentication(SecurityConstants.AuthenticationScheme)
            //   .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(SecurityConstants.AuthenticationScheme, null);
            //services.AddResponseCompression(options =>
            //{
            //    options.EnableForHttps = true;
            //    options.Providers.Add<BrotliCompressionProvider>();
            //    options.Providers.Add<GzipCompressionProvider>();
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //    app.UseDeveloperExceptionPage();

            //app.UseRouting();

            ////Angular Setup
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "ClientApp";
            //    if (env.IsDevelopment())
            //        spa.UseAngularCliServer(npmScript: "start");
            //});

            //// app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            //app.UseCors(); //Enable CORS Policy 

            ////app.UseAuthentication(); //Enable IIS Authentication
            //app.UseResponseCompression(); //Response Compression middleware for faster response times
            //app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
