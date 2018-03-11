using System;
using System.Collections.Generic;
using Dapper;
using domain;

namespace DataAccess
{

    public interface IWriteRepository
    {
        void StoreEvent(Event @event);
        void SetEventStatus(Guid id, string status);
        void StoreTalk(Talk talk);
    }

    public class WriteRepository : IWriteRepository
    {
        private IConnectionProvider _connectionProvider;

        public WriteRepository(IConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public void SetEventStatus(Guid id, string status)
        {
            Enum.TryParse<Event.EventStatus>(status, out var statusEnum);
            if (statusEnum == default(Event.EventStatus)) throw new FormatException("Not a valid status");
            using (var db = _connectionProvider.GetConnection())
            {
                var sql = "Update Event SET Status = @NewStatus WHERE ID=@Id";
                db.Query(sql, new { NewStatus = (int)statusEnum, Id = id });
            }
        }

        public void StoreEvent(Event @event)
        {
            using (var db = _connectionProvider.GetConnection())
            {
                var sql = "INSERT INTO Event(ID, Name, Starts, Ends, Location) values(@Id, @Name, @Starts, @Ends, @Location)";
                db.Query(sql, @event);
            }
        }

        public void StoreTalk(Talk talk)
        {
            using (var db = _connectionProvider.GetConnection())
            {
                var sql = "INSERT INTO Talk " +
                          "values(@Id, @EventId, @Name, @Talker, @Description, @Duration)";
                db.Query(sql, talk);
            }
        }
    }
}