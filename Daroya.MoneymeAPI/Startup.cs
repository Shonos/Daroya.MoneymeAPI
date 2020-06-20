using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Daroya.MoneymeAPI.Database;
using Daroya.MoneymeAPI.Database.Repository;
using Daroya.MoneymeAPI.Models.Models.Requests.Validators;
using Daroya.MoneymeAPI.Services;
using FluentValidation.AspNetCore;
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

namespace Daroya.MoneymeAPI
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
            ConfigureValidators.Configure(services);
            services.AddControllers().AddFluentValidation();
            ConfigureDatabase(services);

            ConfigurationService configService = new ConfigurationService(Configuration);
            services.AddSingleton<IConfigurationService>(configService);

            // todo - separate to another file
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Daroya Moneyme API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            
            var useSqlLite = Configuration.GetValue<bool>("UseSQLLite");
            if (useSqlLite)
            {
                var moneyMeDbConnectionString = Configuration.GetConnectionString("MoneymeContextSqlLite");
                services.AddDbContext<MoneyMeContext>(options => options.UseSqlite(moneyMeDbConnectionString), ServiceLifetime.Transient);
            }
            else
            {
                var moneyMeDbConnectionString = Configuration.GetConnectionString("MoneymeContextSqlLite");
                services.AddDbContext<MoneyMeContext>(options => options.UseSqlServer(moneyMeDbConnectionString), ServiceLifetime.Transient);
            }
        }
    }
}
