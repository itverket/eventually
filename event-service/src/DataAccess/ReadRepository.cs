using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using domain;

namespace DataAccess
{

    public interface IReadRepository
    {
        IEnumerable<Event> GetEvents(string status);
        Event GetEvent(Guid id);
        IEnumerable<Talk> GetTalks(Guid eventId);
    }

    public class ReadRepository : IReadRepository
    {
        private IConnectionProvider _connectionProvider;

        public ReadRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public Event GetEvent(Guid id)
        {
            using (var db = _connectionProvider.GetConnection())
            {
                var sql = "SELECT ID as Id, Name, Starts, Ends, Status, Location from Event " +
                          "WHERE Id = @Id";
                var @event = db.Query<Event>(sql, new { Id = id }).First();
                return @event;
            }
        }

        public IEnumerable<Event> GetEvents(string status)
        {
            Enum.TryParse<Event.EventStatus>(status, out var statusEnum);

            if (statusEnum == default(Event.EventStatus))
            {
                using (var db = _connectionProvider.GetConnection())
                {
                    var sql = "SELECT ID as Id, Name, Starts, Ends, Status, Location from Event";
                    var events = db.Query<Event>(sql);
                    return events;
                }
            }

            using (var db = _connectionProvider.GetConnection())
            {
                var sql = "SELECT ID as Id, Name, Starts, Ends, Status, Location from Event " +
                          "WHERE Status = @Status";
                var events = db.Query<Event>(sql, new { Status = (int)statusEnum });
                return events;
            }
        }

        public IEnumerable<Talk> GetTalks(Guid eventId)
        {
            using (var db = _connectionProvider.GetConnection())
            {
                var sql = "SELECT * from Talk WHERE EventId = @EventId";
                var talks = db.Query<Talk>(sql, new { EventId = eventId });
                return talks;
            }
        }
    }
}