using AutoMapper;
using ExtractImages.Constants;
using ExtractImages.Mapper;
using ExtractImages.Middleware;
using ExtractImages.Services;
using ExtractImages.Services.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace ExtractImages
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }

        //private void InitializeDatabase()
        //{
        //    if (!File.Exists(DbConstants.ConnectionString))
        //    {
        //        Directory.CreateDirectory(DbConstants.ConnectionStringDir);
        //        File.Create(DbConstants.ConnectionString).Dispose();
        //    }
        //}

        //private void InitializeCsvDatabase()
        //{
        //    if (!File.Exists(DbCsvConstants.ConnectionString))
        //    {
        //        Directory.CreateDirectory(DbCsvConstants.ConnectionStringDir);
        //        File.Create(DbCsvConstants.ConnectionString).Dispose();
        //    }
        //}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //InitializeCsvDatabase();

            services.AddMvc(w => w.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            //Services
            services.AddScoped<ImageCommonService>().AddScoped<UserSecurity>();

            //Repositories
     //       services.AddScoped<DatabaseCsvAccess>().AddScoped<IAddressRepository, AddressRepository>()
     //           .AddScoped<IContactsAddressRepository, ContactsAddressRepository>()
     //.AddScoped<IContactsRepository, ContactsRepository>();

            //Mapper
            AutoMapper.MapperConfiguration appConfig = new MapperConfiguration(c => c.AddProfile<ImageMapper>());
            services.AddScoped<IMapper>(c => appConfig.CreateMapper());

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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()  //Allows the client to hardcode keys into the headers for Basic Auth
                );

            app.UseAuthentication(); //Enable IIS Authentication
            app.UseResponseCompression(); //Response Compression middleware for faster response times
            app.UseMvc();
        }
    }
}
