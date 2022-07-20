using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Handlers.Utilities
{
    public interface ITokenGenerator
    {
        string GenerateToken(List<Claim> claims);
    }

    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(List<Claim> claims)
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
