using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using PublicAPI.ApiModels;
using PublicAPI.Data.Attribute;
using PublicAPI.Exception;
using PublicAPI.ExceptionModels;
using PublicAPI.Interface;
using PublicAPI.Interfaces.Ser;
using PublicAPI.Repository;
using PublicAPI.Service;
using PublicAPI.Services;

namespace PublicAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
               //Mvc options

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            }).AddXmlSerializerFormatters();
            //From appSettings

            //Get settings from appsettings.json
            var reactPolicy = Configuration.GetSection("Policies")["ReactPolicy"];
            var reactUrl = Configuration.GetSection("PublicUrls")["ReactUrl"];

            //Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy(reactPolicy,
                    builder => builder.WithOrigins(reactUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //Services
            services.AddTransient<IHttpRepository, HttpRepository>();
            services.AddTransient<IUnicornService, UnicornService>();
            services.AddTransient<IUnicornService, UnicornService>();
            services.AddTransient<IWrapperService, WrapperService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Activate CORS in whole application
            var reactPolicy = Configuration.GetSection("Policies")["ReactPolicy"];
            app.UseCors(reactPolicy);

            AutoMapper.Mapper.Initialize(options =>
            {
                options.CreateMap<CustomApiException, PrettyException>()
                .ReverseMap();

                options.CreateMap<UnicornToAddAPIModel, UnicornApiModel>()
                .ReverseMap();

                options.CreateMap<HornType, HornTypeApiModel>()
                .ReverseMap();
            });

            app.UseHttpsRedirection();
            app.UseMvc();


        }
    }
}
