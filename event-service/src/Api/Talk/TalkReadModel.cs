using System;
namespace Api.Talk
{
    public class TalkReadModel
    {
        public string Name { get; set; }
        public string Talker { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
