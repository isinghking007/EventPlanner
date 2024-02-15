using System.ComponentModel.DataAnnotations;

namespace EventPlanner.Models
{
    public class Login
    {
        [Key]
        public int LoginId { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime LoginTime { get; set; }
    }
}
