using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SampleApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model.Login == "admin" && model.Password == "admin")
            {
                var privateKeyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:Private"]);
                var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(privateKeyBytes),
                    SecurityAlgorithms.HmacSha256);

                var notBefore = DateTime.Now;

                var claims = new List<Claim>()
                {
                    new(ClaimTypes.NameIdentifier, 1.ToString()),
                    new(ClaimTypes.Name, "Mega user"),
                    new(ClaimTypes.Email, "mega@gmail.com"),
                };

                var token = new JwtSecurityToken(
                    claims: claims,
                    notBefore: notBefore,
                    expires: notBefore.AddHours(1),
                    signingCredentials: signingCredentials);

                var tokenString = new JwtSecurityTokenHandler()
                    .WriteToken(token);

                return Ok(tokenString);
            }
            
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("check")]
        public IActionResult CheckLogin()
        {
            return NoContent();
        }
    }
}
