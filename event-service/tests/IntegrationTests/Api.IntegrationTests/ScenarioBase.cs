using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Event;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using Respawn;

namespace Api.IntegrationTests
{
    [TestFixture]
    public abstract class ScenarioBase
    {
        private TestServer _server;
        protected HttpClient Client;
        private static Checkpoint _checkpoint;

        static ScenarioBase()
        {
            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new[]
                {
                    "SchemaVersions",
                }
            };
        }

        [OneTimeSetUp]
        public async Task InitAsync()
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();

            _server = new TestServer(new WebHostBuilder()
                    .UseConfiguration(config)
                .UseStartup<api.Startup>());
            Client = _server.CreateClient();

            var connectionString = config.GetConnectionString("eventually-sql");
            await _checkpoint.Reset(connectionString);
        }

        [SetUp]
        public async Task SetupAsync()
        {
            await Given();
            await When();
        }

        public abstract Task Given();
        public abstract Task When();

        [OneTimeTearDown]
        public void TearDown()
        {
            _server.Dispose();
            Client.Dispose();
        }

        protected async Task<Guid> PostNewEventAsync(DateTime starts, DateTime ends, string location)
        {
            var newEvent = new EventWriteModel
            {
                Name = "TestEvent",
                Starts = starts,
                Ends = ends,
                Location = location
            };

            var content = JsonConvert.SerializeObject(newEvent);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("api/event", stringContent);
            response.EnsureSuccessStatusCode();
            var newId = JsonConvert.DeserializeObject<string>(await response.Content.ReadAsStringAsync());
            Console.WriteLine($"String to parse: {newId}");
            return new Guid(newId);
        }

        protected async Task<EventReadModel> GetEventFromApiAsync(Guid id)
        {
            var getResult = await Client.GetAsync($"api/event/{id}");
            getResult.EnsureSuccessStatusCode();
            var responseString = await getResult.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<EventReadModel>(responseString);
            return data;
        }

        protected async Task<IEnumerable<EventReadModel>> GetEventsFromApiAsync(string status)
        {
            var getResult = await Client.GetAsync($"api/event?status={status}");
            getResult.EnsureSuccessStatusCode();
            var responseString = await getResult.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<EventReadModel>>(responseString);
            return data;
        }

        protected async Task<IEnumerable<domain.Talk>> GetTalksFromApiAsync(Guid eventId)
        {
            var getResult = await Client.GetAsync($"api/event/{eventId}/talk");
            getResult.EnsureSuccessStatusCode();
            var responseString = await getResult.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<IEnumerable<domain.Talk>>(responseString);
            return data;
        }
    }
}