using System.Security.Cryptography;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; private set; }
        public string Email { get; private set; }
        public string Name { get; private set; }
        public string PasswordHash { get; private set; }

        protected User()
        {
            Email = string.Empty;
            Name = string.Empty;
            PasswordHash = string.Empty;
        }

        public User(string email, string passwordHash)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email cannot be null or empty.");

            if (string.IsNullOrEmpty(passwordHash))
                throw new ArgumentException("PasswordHash cannot be null or empty.");

            try{
                UserId = Guid.NewGuid();
                Email = email;
                PasswordHash = passwordHash;
            }catch(Exception e){
                Console.WriteLine("Ocorreu um erro:", e);
                return null;

            }
        }

        public string GeneratePasswordHash(string password, byte[] key)
        {
            using var hmac = new HMACSHA256(key);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return BitConverter.ToString(hmac.ComputeHash(passwordBytes)).Replace("-", "").ToLower();
        }
    }
}