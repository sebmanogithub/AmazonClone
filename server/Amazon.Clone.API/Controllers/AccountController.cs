using System.ComponentModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Amazon.Clone.API.DTOs;
using Amazon.Clone.Core.Entities;
using Amazon.Clone.Core.Interfaces;
using Amazon.Clone.Infrastructure.Data;
using API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IPasswordHashingService _passwordHashingService;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, IPasswordHashingService passwordHashingService,
        ITokenService tokenService)
        {
            _context = context;
            _passwordHashingService = passwordHashingService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Username))
            {
                return BadRequest("UserName is taken");
            }

            (byte[] hash, byte[] salt) = _passwordHashingService.CreatePasswordHashAndSalt(registerDto.Password);
        
            AppUser user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hash,
                PasswordSalt = salt
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user.UserName)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            AppUser? user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.Username);
            
            if (user == null)
            {
                return Unauthorized("Invalid username");
            }

            if (!_passwordHashingService.VerifyPassword(loginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Unauthorized("Invalid Password");
            }

            return new UserDto 
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user.UserName)
            };
        }

        private async Task<bool> UserExists(string UserName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == UserName.ToLower());
        }
    }
}