using BlazorApp2.Models;
namespace BlazorApp2.Services
{
    public class UserService
    {
        private List<User> Users = new List<User>
    {
        new User { Username = "admin", Password = "password", Role = "admin" },
        new User { Username = "agent1", Password = "password", Role = "agent1" },
        new User { Username = "agent2", Password = "password", Role = "agent2" },
        new User { Username = "agent3", Password = "password", Role = "agent3" },
        new User { Username = "customer",Password = "password", Role = "customer" }
    };

        public User AuthenticateUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }

}
