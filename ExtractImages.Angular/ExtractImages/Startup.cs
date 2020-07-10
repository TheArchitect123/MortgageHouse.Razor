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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            //Services
            services.AddScoped<ImageCommonService>()
                .AddScoped<DatabaseServiceAccess>()
                .AddScoped<UserSecurity>();

            //Mapper
            AutoMapper.MapperConfiguration appConfig = new MapperConfiguration(c => c.AddProfile<ImageMapper>());
            services.AddScoped<IMapper>(c => appConfig.CreateMapper());

            //Repositories & Data Access
            services.AddDbContext<ContentDb>(builder => builder.UseSqlServer(DbConstants.DbConnectionString))
            .AddScoped<NewDataRepository>()
           .AddScoped<OldDataRepository>();

            //Gzip Compression
            services.Configure<BrotliCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = System.IO.Compression.CompressionLevel.Optimal);

            //Services for Authentication
            services.AddAuthentication(SecurityConstants.AuthenticationScheme)
               .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>(SecurityConstants.AuthenticationScheme, null);
            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });

            app.UseMvc();
        }
    }
}
