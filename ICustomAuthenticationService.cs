public interface ICustomAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password);
        Task LogoutAsync();
    }
public interface IAdminAuthenticationService
{
    Task<bool> LoginAsync(string username, string password);
    Task LogoutAsync();
}

