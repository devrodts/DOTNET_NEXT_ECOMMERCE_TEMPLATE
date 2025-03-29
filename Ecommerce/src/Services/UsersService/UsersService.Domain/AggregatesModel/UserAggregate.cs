using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.src.Services.UsersService.UsersService.Domain.AggregatesModel
{
    public class UserAggregate
    {

        private readonly HMACSHA3_256 _hmac;
        private readonly string _username;
        private readonly DateTime _createdAt;
        private readonly DateTime _updatedAt;

        public string UserId { get; private set; }



        public UserAggregate(string userData, byte[] key, string username, DateTime createdAt, DateTime updatedAt)
        {
            _hmac = new HMACSHA3_256(key);
            UserId = GenerateUserId(userData);
            _username = username;
            _createdAt = createdAt;
            _updatedAt = updatedAt;
        }

        private string GenerateUserId(string userData)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(userData);
            byte[] hashBytes = _hmac.ComputeHash(dataBytes);
            Console.WriteLine($"generated hash: {hashBytes}");
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

}
