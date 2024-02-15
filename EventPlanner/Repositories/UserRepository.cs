using EventPlanner.DataContext;
using EventPlanner.Interfaces;
using EventPlanner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace EventPlanner.Repositories
{
    public class UserRepository : IUsers
    {
        private readonly DBContext _dbContext;
        public UserRepository(DBContext dbcontext) {
            _dbContext = dbcontext;
        }
        public Users Register(Users user)
        {
             user.CreationDate=DateTime.Now;
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
              
        }
        public Login Login(Login login)
        {
            var data = _dbContext.users.Where(val => val.Email == login.Email && val.Password == login.Password).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            login.LoginTime = DateTime.Now;
            login.Email = data.Email;
            login.Password = data.Password;
            _dbContext.Add(login);
            _dbContext.SaveChanges();
            return login;
        }
    }
}
