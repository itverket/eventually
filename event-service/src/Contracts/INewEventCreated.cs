using System;
using NServiceBus;

namespace Contracts
{
    public interface INewEventCreated : IEvent
    {
        Guid EventId { get; set; }
    }

}
