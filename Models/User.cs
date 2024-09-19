namespace BlazorApp2.Models
{
    public class User
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } // Roles could be "Admin", "Agent", or "Customer"
    }

}
