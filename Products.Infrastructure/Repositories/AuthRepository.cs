using Microsoft.EntityFrameworkCore;
using Products.Core.Entities;
using Products.Core.Repositories;
using Products.Infrastructure.Data;

namespace Products.Infrastructure.Repositories
{
    public class AuthRepository : RepositoryBase<User>, IAuthRepository
    {
        public AuthRepository(CatalogContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<bool> Register(string username, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User();
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Username = username;
            await _dbContext.Users.AddAsync(user);

           return await _dbContext.SaveChangesAsync()>0;

        }

        public async Task<bool> UserExists(string username)
        {
            if (await _dbContext.Users.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

    }
}
