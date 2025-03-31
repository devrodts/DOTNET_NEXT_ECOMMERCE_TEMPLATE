using System.Security.Cryptography;
using System;
using System.Text;

namespace Ecommerce.Services.UsersServices.Domain.Entities
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

            UserId = Guid.NewGuid();
            Email = email;
            Name = string.Empty; // Initialize with empty string
            PasswordHash = passwordHash;
        }

        public void UpdateName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.");
                
            Name = name;
        }

        public void UpdatePasswordHash(string passwordHash)
        {
            if (string.IsNullOrEmpty(passwordHash))
                throw new ArgumentException("PasswordHash cannot be null or empty.");
                
            PasswordHash = passwordHash;
        }

        public string GeneratePasswordHash(string password, byte[] key)
        {
            using var hmac = new HMACSHA256(key);
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return BitConverter.ToString(hmac.ComputeHash(passwordBytes)).Replace("-", "").ToLower();
        }
    }
}
