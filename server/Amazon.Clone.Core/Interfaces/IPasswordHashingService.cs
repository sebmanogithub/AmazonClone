using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Clone.Core.Interfaces
{
    public interface IPasswordHashingService
    {
        (byte[] Hash, byte[] Salt) CreatePasswordHashAndSalt(string password);
        bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt);
    }
}