using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Interfaces
{
    public interface IEvents
    {
        public EventDetails RegisterEvents(EventDetails eventDetails);
        public List<EventDetails> GetEvents(int userId);
        public bool DeleteEvents(int userid, int eventId);
    }
}
