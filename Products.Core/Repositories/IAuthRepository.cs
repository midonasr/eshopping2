using Products.Core.Entities;

namespace Products.Core.Repositories
{
    public interface IAuthRepository
    {
        Task<bool> Register(string username, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}
