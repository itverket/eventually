using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NServiceBus;
using System.Data.SqlClient;
using System;
using Contracts;
using Autofac;

namespace Api.Infrastructure
{
    public static class NServiceBusConfiguration
    {
        public static void ConfigureEndpoint(IEndpointInstance endpoint, IContainer container, string sqlConnectionString)
        {
            var endpointName = "event-service";
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            endpointConfiguration.SendFailedMessagesTo($"{endpointName}.error");
            endpointConfiguration.AuditProcessedMessagesTo($"{endpointName}.audit");
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UseContainer<AutofacBuilder>(
                customizations: customizations =>
                {
                    customizations.ExistingLifetimeScope(container);
                });

            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.ConnectionString(sqlConnectionString);
            transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);

            var routing = transport.Routing();
            routing.RegisterPublisher(typeof(INewEventCreated).Assembly, endpointName);

            endpoint = Endpoint.Start(endpointConfiguration).ConfigureAwait(false).GetAwaiter().GetResult();
        }
    }
}