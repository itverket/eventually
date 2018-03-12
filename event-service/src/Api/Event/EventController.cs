using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace Api.Event
{
    [Route("api/event")]
    public class EventController : Controller
    {
        private readonly IWriteRepository _writeRepo;
        private IReadRepository _readRepo;
        private readonly IEndpointInstance _endpoint;
        private readonly ILogger<EventController> _logger;

        public EventController(IWriteRepository writeRepo, IReadRepository readRepo, IEndpointInstance endpoint, ILoggerFactory logFactory)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
            _endpoint = endpoint;
            _logger = logFactory.CreateLogger<EventController>();
        }

        /// <summary>
        /// Fetches all Events with given statuss filter
        /// </summary>
        /// <param name="status">Optional filter on Event status (Created, RegistrationOpen, Ongoing, Finished). If ommitted returns all events with all statuses</param>   
        [HttpGet]
        public IEnumerable<EventReadModel> GetEvents(string status = null)
        {
            _logger.LogInformation("Request for all events received");
            return _readRepo.GetEvents(status).Select(e => e.MapToReadModel());
        }

        /// <summary>
        /// Fetches specified event 
        /// </summary>
        /// <param name="id">Id of desired event</param>   
        [HttpGet("{id}")]
        public EventReadModel GetEvent(Guid id)
        {
            _logger.LogInformation("Request event {EventId} received!", id);
            return _readRepo.GetEvent(id).MapToReadModel();
        }

        /// <summary>
        /// Creates new event from the request body, and returns the new id 
        /// </summary>
        /// <param name="requestedEvent">Event specification</param>   
        [HttpPost]
        public Guid CreateNewEvent([FromBody]EventWriteModel requestedEvent)
        {
            _logger.LogInformation("Create new event request received");
            var orEvent = requestedEvent.MapToEntity();
            orEvent.Id = Guid.NewGuid();
            _writeRepo.StoreEvent(orEvent);
            return orEvent.Id;
        }

        /// <summary>
        /// Updates the status of specified event. 
        /// </summary>
        /// <param name="id">Id of event to update</param>   
        /// <param name="status">New event status (Created, RegistrationOpen, Ongoing, Finished)</param>   
        [HttpPut("{id}/updateStatus/{status}")]
        public void UpdateEventStatus(Guid id, string status)
        {
            _logger.LogInformation("Update event state for {Id} to {State}", id, status);
            _writeRepo.SetEventStatus(id, status);
        }
    }
}
