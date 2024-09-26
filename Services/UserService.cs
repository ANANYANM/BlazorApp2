using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace BlazorApp2.Services
{
    public class UserService
    {
        private TicketContext _dbContext;

        // Inject the database context through the constructor
        public UserService(TicketContext dbContext)
        {
            _dbContext = dbContext;
        }
        //    private List<User> Users = new List<User>
        //{
        //    new User { Username = "admin", PasswordHash = "password", Role = "admin" },
        //    new User { Username = "agent1", PasswordHash = "password", Role = "agent" },
        //    new User { Username = "agent2", Password = "password", Role = "agent" },
        //    new User { Username = "agent3", Password = "password", Role = "agent" },
        //    new User { Username = "customer",Password = "password", Role = "customer" }
        //};

        // Fetch users from the database based on username and password
        public async Task<User> AuthenticateUser(string username, string password)
        {
            //return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
    }
}
