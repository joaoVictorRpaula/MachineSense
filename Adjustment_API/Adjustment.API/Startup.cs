using Adjustment.Application.Application;
using Adjustment.Application.Interfaces;
using Adjustment.Domain.Interfaces;
using Adjustment.Domain.Services;
using Adjustment.Infrastructure.Configs;
using Adjustment.Infrastructure.Interfaces;
using Adjustment.Infrastructure.Repositories;
using Adjustment.Infrastructure.Services;
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

namespace Adjustment.API
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

            services.AddSingleton<IHttpService, HttpService>();
            services.AddSingleton<IAdjustmentSendToComponentService, AdjustmentResponseInfraService>();
            services.AddSingleton<IAdjustmentResponse, RepositoryAdjustmentResponse>();
            services.AddSingleton<IApplicationAdjustmentResponse, ApplicationAdjustmentResponse>();
            services.AddSingleton<IAdjustmentCalculateResponseService, AdjustmentResponseService>();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Adjustment.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Adjustment.API v1"));
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
