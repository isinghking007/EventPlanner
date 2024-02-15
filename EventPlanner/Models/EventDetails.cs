using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class EventDetails
    {
        [Key]
        public int EventId { get; set; }
        public string EventName { get; set; }
        public int EventPeriod { get; set; }
        public DateTime EventStartDate { get; set; }
        public DateTime EventEndDate { get; set; }

        public string EventDescription { get; set; }

        public DateTime EventCreationDate { get; set; }

    }
}
