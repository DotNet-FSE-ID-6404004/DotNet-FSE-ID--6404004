namespace WebApplication1.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username, string role);
    }
}
