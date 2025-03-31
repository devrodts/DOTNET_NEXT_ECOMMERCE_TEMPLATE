using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Ecommerce.Services.UsersService.UsersService.Domain.AggregatesModel
{
    public class UserAggregate : IDisposable
    {
        private readonly HMACSHA256 _hmac;
        private readonly string _username;
        private readonly DateTime _createdAt;
        private readonly DateTime _updatedAt;

        public string UserId { get; }
        public string Username => _username;
        public DateTime CreatedAt => _createdAt;
        public DateTime UpdatedAt => _updatedAt;

        public UserAggregate(string userData, byte[] key, string username)
        {
            if (string.IsNullOrEmpty(userData))
                throw new ArgumentException("UserData cannot be null or empty.", nameof(userData));
            if (key == null || key.Length == 0)
                throw new ArgumentException("Key cannot be null or empty.", nameof(key));
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            if (username.Length > 50)
                throw new ArgumentException("Username must be at most 50 characters.", nameof(username));
            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9_]+$"))
                throw new ArgumentException("Username contains invalid characters.", nameof(username));
            _hmac = new HMACSHA256(key);
            _username = username;
            _createdAt = DateTime.UtcNow;
            _updatedAt = _createdAt;
            UserId = GenerateUserId(userData);
        }

        private string GenerateUserId(string userData)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(userData);
            byte[] hashBytes = _hmac.ComputeHash(dataBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public void Dispose()
        {
            _hmac?.Dispose();
        }
    }
}