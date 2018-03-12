using System.Threading.Tasks;
using NServiceBus;

namespace Api
{
    public static class NServiceBusConfiguration
    {
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
            // await endpointInstance.Stop()
            //     .ConfigureAwait(false);
        }
    }
}