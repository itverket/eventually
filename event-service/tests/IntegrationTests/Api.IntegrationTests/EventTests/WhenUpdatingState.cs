using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Api.IntegrationTests.EventTests
{
    public class WhenUpdatingState : ScenarioBase
    {
        private Guid _newId;
        private DateTime _eventStarts;
        private DateTime _eventEnds;
        private string _eventLocation;

        public override async Task Given()
        {
            _eventStarts = new DateTime(1991, 9, 16, 20, 0, 0);
            _eventEnds = _eventStarts.AddHours(3);
            _eventLocation = "Kulturhuset";
            _newId = await PostNewEventAsync(_eventStarts, _eventEnds, _eventLocation);
        }

        public override async Task When()
        {
            await PostUpdateStateRequest("Ongoing");
        }

        [Test]
        public async Task Should_Have_New_Status()
        {
            var events = await GetEventsFromApiAsync("Ongoing");
            var @event = events.Single(e => e.Id == _newId);
            Assert.That(@event.Starts == _eventStarts);
            Assert.That(@event.Ends == _eventEnds);
        }

        public async Task PostUpdateStateRequest(string newStatus)
        {
            var response = await Client.PutAsync($"api/event/{_newId}/updateStatus/{newStatus}", null);
            response.EnsureSuccessStatusCode();
        }
    }
}

