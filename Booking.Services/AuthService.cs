using Booking.Data;
using Booking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Booking.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly BookingDbContext _context;

        public AuthService(IConfiguration configuration, BookingDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<string> LoginAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public string Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            var claims = GetUserClaims(user);

            return GenerateToken(claims);
        }

        private static List<Claim> GetUserClaims(User user)
        {
            return new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
            };
        }

        private string GenerateToken(List<Claim> claims)
        {
            var notBefore = DateTime.Now;
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(_configuration["Jwt:Private"]), out _);

            var signingCredentials = new SigningCredentials(
                    new RsaSecurityKey(rsa),
                    SecurityAlgorithms.RsaSha512);

            var token = new JwtSecurityToken(
                    claims: claims,
                    notBefore: notBefore,
                    expires: notBefore.AddHours(1),
                    signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }

    }
}
