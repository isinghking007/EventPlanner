using Microsoft.EntityFrameworkCore;
using System.Configuration;
using EventPlanner.Models;

namespace EventPlanner.DataContext
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) :base(options){ }

        public DbSet<Users> users { get; set; }
        public DbSet<EventDetails> eventDetails { get; set; }

        public DbSet<Login> login { get; set; }
    }
}
