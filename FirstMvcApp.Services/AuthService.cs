using FirstMvcApp.Database;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace FirstMvcApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserDbContext _context;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserDbContext context,
            ILogger<AuthService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public ClaimsPrincipal Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email
                && u.Password == password);

            if (user == null)
            {
                throw new NotFoundException("User login failed");
            }

            _logger.LogInformation($"login for user with id: {user.Id}");

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
            };

            ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new(new ClaimsIdentity(identity));

            return principal;
        }
    }
}