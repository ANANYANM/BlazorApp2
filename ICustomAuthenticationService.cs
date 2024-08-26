namespace BlazorApp2;
public interface ICustomAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
    }


