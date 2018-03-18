using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NServiceBus;

namespace Api.Form
{
    [Route("api/form")]
    public class FormController : Controller
    {
        private readonly ILogger<FormController> _logger;
        private readonly IEndpointInstance _endpoint;

        public FormController(IEndpointInstance endpoint, ILoggerFactory logFactory)
        {
            _endpoint = endpoint;
            _logger = logFactory.CreateLogger<FormController>();
        }

        /// <summary>
        /// Fetches all feedback forms
        /// </summary>
        [HttpGet]
        public IEnumerable<string> GetForms()
        {
            _logger.LogInformation("Request for forms received");
            return new List<string>();
        }

        /// <summary>
        /// Fetches specified form by event id 
        /// </summary>
        /// <param name="eventId">Id of event the form is connected to</param>   
        [HttpGet("{eventId}")]
        public string GetForm(Guid eventId)
        {
            _logger.LogInformation("Request form connected to  {EventId} received!", eventId);
            return $"This is a form connected to event with id {eventId}";
        }
    }
}
