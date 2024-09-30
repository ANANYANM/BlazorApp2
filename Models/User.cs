using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } // Roles could be "Admin", "Agent", or "Customer"
        public string? Name { get; set; }
        public string? Company { get; set; }
    }

}
