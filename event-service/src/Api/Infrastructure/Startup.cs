using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Contracts;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NServiceBus;
using Swashbuckle.AspNetCore.Swagger;

namespace Api.Infrastructure
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.ConfigureWebApi();
            services.ConfigureSwagger();

            IEndpointInstance endpoint = null;
            var sqlConnectionString = Configuration.GetConnectionString("eventually-sql");
            var container = services.ConfigureContainer(endpoint, sqlConnectionString);
            NServiceBusConfiguration.ConfigureEndpoint(endpoint, container, sqlConnectionString);

            return new AutofacServiceProvider(container);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            AddLogger(loggerFactory);
            AddMvc(app);
        }

        private void AddLogger(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddAzureWebAppDiagnostics();
        }
        
        private void AddMvc(IApplicationBuilder app)
        {
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eventually Api");
            });

            app.UseCors("AllowSpecificOrigin");
        }
    }
}