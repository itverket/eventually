using System;

namespace Api.Event
{
    public static class Mapping
    {
        public static domain.Event MapToEntity(this EventReadModel readModel)
        {
            return new domain.Event
            {
                Id = Guid.NewGuid(),
                Name = readModel.Name,
                Starts = readModel.Starts,
                Ends = readModel.Ends,
                Location = readModel.Location
            };
        }

        public static EventReadModel MapToReadModel(this domain.Event orEvent)
        {
            return new EventReadModel
            {
                Id = orEvent.Id,
                Name = orEvent.Name,
                Starts = orEvent.Starts,
                Ends = orEvent.Ends,
                Location = orEvent.Location
            };
        }

        public static domain.Event MapToEntity(this EventWriteModel readModel)
        {
            return new domain.Event
            {
                Id = Guid.NewGuid(),
                Name = readModel.Name,
                Starts = readModel.Starts,
                Ends = readModel.Ends,
                Location = readModel.Location
            };
        }

        public static EventWriteModel MapToWriteModel(this domain.Event orEvent)
        {
            return new EventWriteModel
            {
                Name = orEvent.Name,
                Starts = orEvent.Starts,
                Ends = orEvent.Ends,
                Location = orEvent.Location
            };
        }
    }
}
