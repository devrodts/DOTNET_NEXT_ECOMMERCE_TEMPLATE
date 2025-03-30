using Application.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.src.Services.UsersService.UsersService.Infrastructure.Security.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        private readonly byte[] _key;

        public PasswordHasher(byte[] key)
        {
            _key = key ?? throw new ArgumentNullException(nameof(key));
        }

        public string HashPassword(string password)
        {
            using var hmac = new HMACSHA256(_key);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = hmac.ComputeHash(passwordBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var hashedInput = HashPassword(password);
            return hashedInput.Equals(hashedPassword, StringComparison.Ordinal);
        }
    }
}