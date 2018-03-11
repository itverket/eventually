using System;
namespace Api.Talk
{
    public static class Mapping
    {
        public static TalkReadModel MapToReadModel(this domain.Talk talk)
        {
            return new TalkReadModel
            {
                Name = talk.Name,
                Talker = talk.Talker,
                Description = talk.Description,
                Duration = talk.Duration
            };
        }

        public static domain.Talk MapToEntity(this TalkReadModel talk)
        {
            return new domain.Talk
            {
                Name = talk.Name,
                Talker = talk.Talker,
                Description = talk.Description,
                Duration = talk.Duration
            };
        }

        public static domain.Talk MapToEntity(this TalkWriteModel talk)
        {
            return new domain.Talk
            {
                Name = talk.Name,
                Talker = talk.Talker,
                Description = talk.Description,
                Duration = talk.Duration
            };
        }
    }
}
