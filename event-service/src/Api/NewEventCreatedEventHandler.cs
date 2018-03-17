using System.Threading.Tasks;
using Contracts;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace Api
{
    public class NewEventCreatedEventHandler : IHandleMessages<INewEventCreated>
    {
        private readonly ILogger<NewEventCreatedEventHandler> _logger;
        
        public NewEventCreatedEventHandler(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<NewEventCreatedEventHandler>();
        }

        public Task Handle(INewEventCreated message, IMessageHandlerContext context)
        {
            _logger.LogInformation("Handling event created event");
            return Task.CompletedTask;
        }
    }
}