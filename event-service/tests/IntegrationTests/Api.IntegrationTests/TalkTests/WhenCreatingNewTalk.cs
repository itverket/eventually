using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Api.IntegrationTests.TalkTests
{
    public class WhenCreatingNewTalk : ScenarioBase
    {
        private Guid _eventId;

        public override async Task Given()
        {
            var eventStarts = new DateTime(1991, 9, 16, 20, 0, 0);
            var eventEnds = eventStarts.AddHours(3);
            _eventId = await PostNewEventAsync(eventStarts, eventEnds, "Kulturhuset");
        }

        public override async Task When()
        {
            await PostNewTalkAsync();
            await PostNewTalkAsync();
        }

        [Test]
        public async Task Should_Return_Two_Talks()
        {
            var talks = await GetTalksFromApiAsync(_eventId);
            Assert.That(talks.Count() == 2);
        }

        public async Task PostNewTalkAsync()
        {
            var newTalk = new domain.Talk
            {
                Name = "Talk about something interesting",
                Talker = "Anders Kofoed",
                Description = "Talk describing something cool about the interesting thing",
                Duration = 45
            };

            var content = JsonConvert.SerializeObject(newTalk);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync($"api/event/{_eventId}/talk", stringContent);

            response.EnsureSuccessStatusCode();
        }
    }
}

