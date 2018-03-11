using System;
namespace Api.Event
{
    public class EventReadModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
    }
}
