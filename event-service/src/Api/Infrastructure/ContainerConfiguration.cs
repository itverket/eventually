using Autofac;
using Autofac.Extensions.DependencyInjection;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace Api.Infrastructure
{
    public static class ContainerConfiguration
    {
        public static IContainer ConfigureContainer(this IServiceCollection services, 
            IEndpointInstance endpoint, string sqlConnectionString)
        {
            services.AddSingleton<IConnectionProvider>(_ => new ConnectionProvider(sqlConnectionString));
            services.AddSingleton<IReadRepository, ReadRepository>();
            services.AddSingleton<IWriteRepository, WriteRepository>();
           
            //Connect with autofac 
            var builder = new ContainerBuilder();
            builder.Populate(services);

            //Register NSB endpoint
            builder.Register(c => endpoint)
                .As<IEndpointInstance>()
                .SingleInstance();

            var container = builder.Build();
            return container;
        }
    }
}