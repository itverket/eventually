using System;
using System.Threading.Tasks;
using Contracts;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace MessageEndpoint
{
    public class NewEventCreatedEventHandler : IHandleMessages<INewEventCreated>
    {
        public Task Handle(INewEventCreated message, IMessageHandlerContext context)
        {
            ApplicationLogging.CreateLogger().LogInformation("Event received in feedback service!!");
            return Task.CompletedTask;
        }
    }
}