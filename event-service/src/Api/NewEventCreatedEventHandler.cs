using System.Threading.Tasks;
using Contracts;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace Api
{
    public class NewEventCreatedEventHandler : IHandleMessages<INewEventCreated>
    {
        public Task Handle(INewEventCreated message, IMessageHandlerContext context)
        {
            return Task.FromResult(1);
        }
    }
}