using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Api;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NServiceBus;
using NServiceBus.Features;
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
            services.AddMvc();
            services.ConfigureSwagger();
           
            var builder = new ContainerBuilder();
            builder.Populate(services);

            IEndpointInstance endpoint = null;
            builder.Register(c => endpoint)
                .As<IEndpointInstance>()
                .SingleInstance();

            var container = builder.Build();

            var endpointName = "feedback-service";
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            endpointConfiguration.SendOnly();
            endpointConfiguration.DisableFeature<MessageDrivenSubscriptions>();
            var sqlConnectionString = Configuration.GetConnectionString("eventually-sql");
            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.ConnectionString(sqlConnectionString);
            transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);
            endpoint = Endpoint.Start(endpointConfiguration).ConfigureAwait(false).GetAwaiter().GetResult();

            return new AutofacServiceProvider(container);
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
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "Eventually Feedback Api");
           });
        }
    }
}