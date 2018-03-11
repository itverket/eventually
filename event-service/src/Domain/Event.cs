using System;

namespace domain
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public DateTime Starts { get; set; }
        public DateTime Ends { get; set; }
        public EventStatus Status { get; set; }

        public enum EventStatus
        {
            Created = 0,
            RegistrationOpen = 1,
            Ongoing = 2,
            Finished = 3
        }
    }
}
