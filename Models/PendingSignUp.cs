namespace BlazorApp2.Models
{
    public class PendingSignUp
    {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Company { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
        public string? Role { get; set; }
            public bool IsApproved { get; set; } // Admin approval status
     
    }
}
