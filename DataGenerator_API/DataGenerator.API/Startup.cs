using DataGenerator.Application.Application;
using DataGenerator.Application.Interfaces;
using DataGenerator.Domain.Interfaces;
using DataGenerator.Domain.InterfacesServices;
using DataGenerator.Domain.Services;
using DataGenerator.Infrastructure.Configs;
using DataGenerator.Infrastructure.Interfaces;
using DataGenerator.Infrastructure.Repositories;
using DataGenerator.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataGenerator.API
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
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            services.AddSerilog(logger);

            services.AddDbContext<Context>(op =>
                op.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")),
                    contextLifetime: ServiceLifetime.Singleton);
            services.AddHttpClient();
            //INTERFACE DOM -> REPOSITORY INFRA
            services.AddSingleton<IResultData, RepositoryResultData>();
            services.AddSingleton<IDataResponse, DataResponseInfraService>();
            services.AddSingleton<IHttpService, HttpService>();

            //INTERFACE APP
            services.AddSingleton<IApplicationResultData, ApplicationResultData>();
            services.AddSingleton<IApplicationDataResponse, ApplicationDataResponse>();
            services.AddSingleton<IDataResponseService, DataResponseService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DataGenerator.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DataGenerator.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
