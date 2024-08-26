namespace BlazorApp2;
public class CustomAuthenticationService : ICustomAuthenticationService
    {
        public Task<bool> LoginAsync(string username, string password)
        {
            // Implement your login logic here
            // Return true if login is successful, otherwise false
            return Task.FromResult(username == "admin" && password == "password"); // Example logic
        }

        public Task LogoutAsync()
        {
            return Task.CompletedTask;
        }
    }

