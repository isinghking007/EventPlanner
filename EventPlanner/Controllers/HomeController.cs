using EventPlanner.DataContext;
using EventPlanner.Interfaces;
using EventPlanner.Models;
using EventPlanner.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventPlanner.Controllers
{
    /*[Authorize]*/
    [ApiController]
    [Route("Api/[controller]")]
    public class HomeController : ControllerBase
    {
        #region Declarations and Constructor
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

        #endregion Declarations and Constructor

        #region Get Methods

        [HttpGet("userDetails")]
        public IActionResult UserDetails()
        {
           var data=users.GetDetails();
            if(data == null)
            {
                return Ok("No specific user exits");
            }
            return Ok(data);
        }

        [HttpGet("eventDetails/{userId}")]
        public IActionResult GetDetails(int userId)
        {
            var data = events.GetEvents(userId);
            if (data == null)
            {
                return Ok("Either user or events are not available");
            }
            return Ok(data);
        }
#endregion Get Methods

        #region Post Methods
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
        #endregion Post Methods

        #region Put Records
        [HttpPut("updateDetails/{user}")]
        public IActionResult UpdateDetails(Users user)
        {
            var data = users.UpdateDetails(user);
            if (data == null)
            {
                return Ok("User doesn't exists");
            }
            return Ok(data);

        }
        #endregion Put Records

        #region Delete Records

        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var data = users.DeleteUser(id);
            if(data==false)
            {
                return Ok("User doesn't exist");
            }
            return Ok("User Delete Successfully");
        }
        #endregion Delete Records
    }
}
