using EventPlanner.DataContext;
using EventPlanner.Interfaces;
using EventPlanner.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Repositories
{
    public class EventRepository : IEvents
    {
        DBContext dbContext;
        public EventRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public EventDetails RegisterEvents(EventDetails eventDetails)
        {
            eventDetails.EventCreationDate = DateTime.Now;
            dbContext.Add(eventDetails);
            dbContext.SaveChanges();
            return eventDetails;
        }
        
    }
}
