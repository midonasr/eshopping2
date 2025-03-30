

namespace Products.Application.Services
{
    public interface IAuthService
    {
        Task<bool> Register(string username, string password);
        Task<string> Login(string username, string password); 
    }
}
