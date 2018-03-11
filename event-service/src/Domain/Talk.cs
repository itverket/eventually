using System;

namespace domain
{
    public class Talk
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public string Talker { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
