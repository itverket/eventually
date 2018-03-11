using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Talk
{
    [Route("api/event")]
    public class TalkController : Controller
    {
        private readonly IWriteRepository _writeRepo;
        private IReadRepository _readRepo;
        private readonly ILogger<TalkController> _logger;

        public TalkController(IWriteRepository writeRepo, IReadRepository readRepo, ILoggerFactory logFactory)
        {
            _writeRepo = writeRepo;
            _readRepo = readRepo;
            _logger = logFactory.CreateLogger<TalkController>();
        }

        /// <summary>
        /// Fetches all talks connected to the specified event 
        /// </summary>
        /// <param name="eventId">Id of parent event</param>   
        [HttpGet("{eventId}/talk")]
        public IEnumerable<TalkReadModel> GetTalks(Guid eventId)
        {
            _logger.LogInformation("Request for talks in event {EventId} received!", eventId);
            return _readRepo.GetTalks(eventId).Select(t => t.MapToReadModel());
        }

        /// <summary>
        /// Creates new talk connected to specified event 
        /// </summary>
        /// <param name="eventId">Id of parent event</param>   
        /// <param name="newTalk">Talk specifications</param>   
        [HttpPost("{eventId}/talk")]
        public Guid CreateNewEvenlt(Guid eventId, [FromBody]TalkWriteModel newTalk)
        {
            _logger.LogInformation("Add talk to event {EventId} received", eventId);
            var orTalk = newTalk.MapToEntity();
            orTalk.EventId = eventId;
            orTalk.Id = Guid.NewGuid();
            _writeRepo.StoreTalk(orTalk);
            return orTalk.Id;
        }
    }
}
