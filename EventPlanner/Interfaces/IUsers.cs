using EventPlanner.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Interfaces
{
    public interface IUsers
    {
        public Users Register(Users user);

        public Login Login(Login login);
       
    }
}
