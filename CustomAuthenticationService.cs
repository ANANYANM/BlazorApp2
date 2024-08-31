namespace BlazorApp2;
public class CustomAuthenticationService : ICustomAuthenticationService
    {
        public Task<bool> LoginAsync(string username, string password)
        {
            return Task.FromResult(username == "admin" && password == "password"); // Example logic
        }

        public Task LogoutAsync()
        {
            return Task.CompletedTask;
        }
    }

