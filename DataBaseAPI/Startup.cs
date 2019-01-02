using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseAPI.ApiModels;
using DataBaseAPI.Data.Entities.Context;
using DataBaseAPI.DataAccess;
using DataBaseAPI.DataAccess.Seeder;
using DataBaseAPI.Interfaces;
using DataBaseAPI.Interfaces.Ser;
using DataBaseAPI.Models;
using DataBaseAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DataBaseAPI
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
            //Set Database configuration
            services.AddDbContext<UnicornContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("UnicornConnectionString"));
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Get settings from appsettings.json
            var Policy = Configuration.GetSection("Policies")["DatabasePolicy"];
            var Url = Configuration.GetSection("PublicUrls")["PublicApiUrl"];

            //Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy(Policy,
                    builder => builder.WithOrigins(Url)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //RegisterServices
            services.AddTransient<IUnicornRepository, UnicornRepository>();
            services.AddTransient<IUnicornService, UnicornService>();
            services.AddTransient<IWrapperService, WrapperService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UnicornContext unicornContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //Initialize AutoMapper
            AutoMapper.Mapper.Initialize(options =>
            {
                //Unicorns
                options.CreateMap<UnicornApiModel, Unicorn>()
                .ReverseMap();
                //HornTypes
                options.CreateMap<HornTypeApiModel, HornType>()
                .ReverseMap();

            });

            //SeedDatabase
            unicornContext.SeedUnicorns();

            //Activate CORS in whole application
            var Policy = Configuration.GetSection("Policies")["DatabasePolicy"];
            app.UseCors(Policy);

            app.UseHttpsRedirection();

            app.UseMvc();
        }
    }
}
