using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NServiceBus;
using Swashbuckle.AspNetCore.Swagger;

namespace api
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
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("v1", new Info { Title = "Eventually API", Version = "v1" });
               var basePath = AppContext.BaseDirectory;
               var xmlPath = Path.Combine(basePath, "Api.xml");
               c.IncludeXmlComments(xmlPath);
               c.DescribeAllEnumsAsStrings();
            });

            var endpoint = NServiceBusConfiguration.StartEndpoint(Configuration.GetConnectionString("eventually-sql"));
            services.AddSingleton<IEndpointInstance>(endpoint);

            //Application services
            services.AddSingleton<IConnectionProvider>(_ => new ConnectionProvider(Configuration.GetConnectionString("eventually-sql")));
            services.AddSingleton<IReadRepository, ReadRepository>();
            services.AddSingleton<IWriteRepository, WriteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Logging
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddAzureWebAppDiagnostics();

            //Web Api
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eventually Api");
           });
        }
    }
}