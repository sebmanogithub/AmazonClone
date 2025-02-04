using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Clone.Core.Entities;

namespace Amazon.Clone.Core.Interfaces
{
    public interface ITokenService
    {
         string CreateToken(string username);
    }
}