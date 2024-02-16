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

        public List<EventDetails> GetEvents(int userId)
        {
            var data = dbContext.users.Where(val => val.UserId == userId).FirstOrDefault();
            if(data ==null)
            {
                return null;
            }
            var eventDetails = dbContext.eventDetails.ToList();
            if(eventDetails.Count == 0)
            {
                return null;
            }
            return eventDetails;
        }

        public bool DeleteEvents(int userid, int eventId)
        {

            var userAvalaibility = dbContext.users.Where(val => val.UserId == userid).FirstOrDefault();
            if(userAvalaibility == null)
            {
                return false;
            }
            var eventAvalaibilty = dbContext.eventDetails.Where(val => val.EventId == eventId && val.userId == userid).FirstOrDefault();
            if(eventAvalaibilty == null)
            {
                return false;
            }
            dbContext.Remove(eventAvalaibilty);
            dbContext.SaveChanges();
            return true;
        }
        
    }
}
