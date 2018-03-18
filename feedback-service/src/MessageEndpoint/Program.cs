using System;
using System.IO;
using System.Threading;
using Contracts;
using Microsoft.Extensions.Configuration;
using NServiceBus;
using NServiceBus.Features;

namespace MessageEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var sqlConnectionString = configuration.GetConnectionString("eventually-sql");
            var endpointName = "feedback-service";
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
            endpointConfiguration.SendFailedMessagesTo($"{endpointName}.error");
            endpointConfiguration.AuditProcessedMessagesTo($"{endpointName}.audit");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            
            transport.ConnectionString(sqlConnectionString);
            transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);

            var routing = transport.Routing();
            routing.RegisterPublisher(
                assembly: typeof(INewEventCreated).Assembly,
                publisherEndpoint: "event-service");

            var endpoint = Endpoint.Start(endpointConfiguration).ConfigureAwait(false).GetAwaiter().GetResult();
            while (true)
            {
                Thread.Sleep(3000);
            }
        }
    }
}
