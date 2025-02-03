using System.Security.Cryptography;
using System.Text;
using Amazon.Clone.Core.Interfaces;

namespace Amazon.Clone.Core.Services
{
    public class PasswordHashingService : IPasswordHashingService
    {
        public (byte[] Hash, byte[] Salt) CreatePasswordHashAndSalt(string password)
        {
            using var hmac = new HMACSHA512();

            return (hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), 
                    hmac.Key);
        }

        public bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            using var hmac = new HMACSHA512(storedSalt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != storedHash[i])
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}