using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Interfaces
{
    public interface IEvents
    {
        public EventDetails RegisterEvents(EventDetails eventDetails);
    }
}
