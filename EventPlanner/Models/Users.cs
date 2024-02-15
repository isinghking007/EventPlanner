using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        
        public string Password { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
