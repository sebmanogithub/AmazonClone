using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Amazon.Clone.Core.Entities;
using Amazon.Clone.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Amazon.Clone.Core.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            string tokenKey = config["TokenKey"] ?? 
            throw new ArgumentNullException(nameof(config), "TokenKey not found in configuration");
            
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        }

        public string CreateToken(string username)
        {
            // Informations relatives au header - Authentification / Identifiants
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            // Informations relatives au payload
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, username)
            };
        
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            // Informations relatives à la signature
            // JwtSecurityTokenHandler : Responsable de la création et de la 
            // validation des tokens
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}