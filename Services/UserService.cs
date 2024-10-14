using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
namespace BlazorApp2.Services
{
    public class UserService(TicketContext dbContext)
    {
        private readonly TicketContext _dbContext = dbContext;

        public TicketContext Get_dbContext()
        {
            return _dbContext;
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
        public async Task<User?> AuthenticateUser(string username, string password)
        {
            // return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return await _dbContext.Users
            .FirstOrDefaultAsync(u => u.Username == username && u.Password == password && u.IsApproved == true);
        }
        public async Task<List<User>> GetAgentsAsync()
        {
            return await _dbContext.Users.Where(u => u.Role == "Agent").ToListAsync();
        }
        public async Task DeleteAgentAsync(int userId)
        {
            // Find the agent in the database by userId
            var agent = await _dbContext.Users.FindAsync(userId);
            if (agent != null)
            {
                // Remove the agent and save changes
                _dbContext.Users.Remove(agent);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task UpdateAgentAsync(User agent)
        {
            // Update the agent in the database
            _dbContext.Users.Update(agent);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<User?> GetAgentByIdAsync(int userId)
        {
            // Fetch the agent by userId from the database
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == userId);
        }

    }
}
