using EventPlanner.DataContext;
using EventPlanner.Interfaces;
using EventPlanner.Models;
using EventPlanner.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventPlanner.Controllers
{
    [Authorize]
    [ApiController]
    [Route("Api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly DBContext dbcontext;
        private readonly IEvents events;
        private readonly IUsers users;
        private readonly IConfiguration config;
        public HomeController(DBContext dbcontext,IEvents events,IUsers users,IConfiguration config) 
        {
            this.dbcontext=dbcontext;
            this.events = events;
            this.users = users;
            this.config = config;
        }

        [HttpGet("Demo")]
        public string Demo()
        {
            return "Hello world";
        }

        [HttpPost("AddEventDetails")]
        public IActionResult EventDetails(EventDetails eventDetails)
        {
            EventDetails eventDetails1=events.RegisterEvents(eventDetails);
            if(eventDetails1== null)
            {
                return Ok("Not Added");
            }
            return Ok(eventDetails1);
        }
        [HttpPost("AddUsers")]
        public IActionResult AddUserDetails(Users user)
        {
            Users _user = users.Register(user);
            if(_user == null)
            {
                return Ok("Not Added");
            }
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(Login login)
        {
            Login _login = users.Login(login);
            if(_login ==null)
            {
                return Ok("Incorrect Credential Details");
            }
            return Ok(new JWTServices(config).GenerateLoginToken(login.LoginId.ToString(),login.Email));
        }
    }
}
