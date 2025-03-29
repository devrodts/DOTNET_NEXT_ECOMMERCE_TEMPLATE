using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.AggregatesModel
{
    public class UserAggregate
    {
        private readonly HMACSHA256 _hmac;
        private readonly string _username;
        private readonly DateTime _createdAt;
        private readonly DateTime _updatedAt;

        public string UserId { get; private set; }

        public UserAggregate(string userData, byte[] key, string username, DateTime createdAt, DateTime updatedAt)
        {
            if (string.IsNullOrEmpty(userData))
                throw new ArgumentException("UserData cannot be null or empty.");
            if (key == null || key.Length == 0)
                throw new ArgumentException("Key cannot be null or empty.");
            if (string.IsNullOrEmpty(username))
                throw new ArgumentException("Username cannot be null or empty.");

            _hmac = new HMACSHA256(key);
            UserId = GenerateUserId(userData);
            _username = username;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }

        private string GenerateUserId(string userData)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(userData);
            byte[] hashBytes = _hmac.ComputeHash(dataBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }

        public string Username => _username;
        public DateTime CreatedAt => _createdAt;
        public DateTime UpdatedAt => _updatedAt;
    }
}