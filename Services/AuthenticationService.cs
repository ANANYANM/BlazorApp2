namespace BlazorApp2.Services;

public class AuthenticationService
{
    public async Task<bool> IsValidUser(string username, string password)
    {
        await Task.Delay(100); // Simulate some asynchronous operation.
        return true;
    }
}

