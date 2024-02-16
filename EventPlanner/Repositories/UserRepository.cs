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

        public List<Users> GetDetails()
        {
            var userdata=_dbContext.users.ToList();
            if(userdata == null)
            {
                return null;
            }
            return userdata;
        }

        public  Users UpdateDetails(Users user)
        {
            var data = _dbContext.users.Find(user.UserId);
            if(data==null)
            {
                return null;
            }
            data.FirstName = user.FirstName;
            data.LastName = user.LastName;
            data.Phone = user.Phone;
            data.Email = user.Email;
            data.Password = user.Password;
           
            _dbContext.SaveChanges();
            return data;
        }
        public bool DeleteUser(int id)
        {
            var data = _dbContext.users.Find(id);
            if(data == null)
            {
                return false;
            }
            _dbContext.Remove(data);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
