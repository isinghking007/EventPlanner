using EventPlanner.DataContext;
using EventPlanner.Interfaces;
using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EventController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly DBContext dbcontext;
        private readonly IEvents events;
        private readonly IUsers users;
       
        public EventController(IConfiguration config,DBContext dbcontext,IEvents events,IUsers users) 
        {
            this.dbcontext = dbcontext;
            this.events = events;
            this.users = users;
            this.config = config;
        }

        #region Get Methods
        [HttpGet("eventDetails/{userId}")]
        public IActionResult GetDetails(int userId)
        {
            var data=events.GetEvents(userId);
            if(data == null)
            {
                return Ok("Either user or events are not available");
            }
            return Ok(data);
        }
        #endregion Get Methods
        #region Post Methods
        [HttpPost("AddEventDetails")]
        public IActionResult EventDetails(EventDetails eventDetails)
        {
            EventDetails eventDetails1 = events.RegisterEvents(eventDetails);
            if (eventDetails1 == null)
            {
                return Ok("Not Added");
            }
            return Ok(eventDetails1);
        }
        #endregion Post Methods


        #region Delete Methods
        [HttpDelete("deleteEvent/{userId}/{eventId}")]
        public IActionResult DeleteEvent(int userId,int eventId)
        {
            var data = events.DeleteEvents(userId, eventId);
            if(data==null)
            {
                return Ok("No Event has been created by User");
            }
            return Ok(data);
        }
        #endregion Delete Methods
    }
}
