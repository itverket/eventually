using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Api.IntegrationTests.EventTests
{
    public class WhenCreatingNewEvent : ScenarioBase
    {
        private Guid _newId;
        private DateTime _eventStarts;
        private DateTime _eventEnds;
        private string _eventLocation;

        public override Task Given()
        {
            _eventStarts = new DateTime(1991, 9, 16, 20, 0, 0);
            _eventEnds = _eventStarts.AddHours(3);
            _eventLocation = "Kulturhuset";
            return Task.FromResult(1);
        }

        public override async Task When()
        {
            _newId = await PostNewEventAsync(_eventStarts, _eventEnds, _eventLocation);
        }

        [Test]
        public async Task Should_Be_New_Event_Available()
        {
            var @event = await GetEventFromApiAsync(_newId);
            Assert.That(@event.Id == _newId);
            Assert.That(@event.Starts == _eventStarts);
            Assert.That(@event.Ends == _eventEnds);
            Assert.That(@event.Location == _eventLocation);
        }
    }
}

