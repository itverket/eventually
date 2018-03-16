using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NServiceBus;
using System.Data.SqlClient;
using System;
using Contracts;

namespace Api.Infrastructure
{
    public static class NServiceBusConfiguration
    {
        public static void RegisterNserviceBusEndpoint(this IServiceCollection services, string connectionString)
        {
            var endpoint = NServiceBusConfiguration.StartEndpoint(connectionString);
            services.AddSingleton<IEndpointInstance>(endpoint);
        }

        public static IEndpointInstance StartEndpoint(string connectionString)
        {
            var endpointName = "event-service";
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            endpointConfiguration.SendFailedMessagesTo($"{endpointName}.error");
            endpointConfiguration.AuditProcessedMessagesTo($"{endpointName}.audit");
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.EnableInstallers();

            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.ConnectionString(connectionString);
            transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);

            var routing = transport.Routing();
            routing.RegisterPublisher(typeof(INewEventCreated).Assembly, endpointName);

            var endpointInstance = Endpoint.Start(endpointConfiguration).ConfigureAwait(false).GetAwaiter().GetResult();
            return endpointInstance;
        }
    }
}