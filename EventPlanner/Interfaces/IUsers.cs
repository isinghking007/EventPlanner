using EventPlanner.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanner.Interfaces
{
    public interface IUsers
    {
        public Users Register(Users user);

        public Login Login(Login login);
        public List<Users> getUserDetail(string email);
        public List<Users> GetUserDetails(int userid);
        public List<Users> GetDetails();

        public Users UpdateDetails(Users user);
        public bool DeleteUser(int id);
    }
}
