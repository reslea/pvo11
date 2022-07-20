using Booking.Data;
using Booking.Data.Entities;
using Booking.Handlers.Utilities;
using Booking.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Booking.Handlers.Auth;

public class LoginDto : IRequest<string> 
{ 
    public string Login { get; set; }
    public string Password { get; set; }
}

public class LoginHandler : IRequestHandler<LoginDto, string>
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly BookingDbContext _context;

    public LoginHandler(ITokenGenerator tokenGenerator, BookingDbContext context)
    {
        _tokenGenerator = tokenGenerator;
        _context = context;
    }

    public async Task<string> Handle(LoginDto request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstAsync(u => u.Name == request.Login && u.Password == request.Password);
        
        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email),
        };

        return _tokenGenerator.GenerateToken(claims);
    }
}
