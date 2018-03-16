using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using NServiceBus;

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
            var endpointConfiguration = new EndpointConfiguration("Samples.SqlServer.SimpleSender");
            endpointConfiguration.SendFailedMessagesTo("error");
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.EnableInstallers();

            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            transport.ConnectionString(connectionString);
            transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);

            var endpointInstance = Endpoint.Start(endpointConfiguration).ConfigureAwait(false).GetAwaiter().GetResult();
            return endpointInstance;
        }
    }
}