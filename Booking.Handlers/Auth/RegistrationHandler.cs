using Booking.Data;
using Booking.Data.Entities;
using Booking.Handlers.Utilities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Booking.Handlers.Auth;

public class RegistrationHandler : IRequestHandler<RegistrationDto, string>
{
    private readonly IValidator<RegistrationDto> _validator;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly BookingDbContext _context;

    public RegistrationHandler(
        IValidator<RegistrationDto> validator,
        ITokenGenerator tokenGenerator,
        BookingDbContext context)
    {
        _validator = validator;
        _tokenGenerator = tokenGenerator;
        _context = context;
    }

    public async Task<string> Handle(RegistrationDto request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        byte[] salt = RandomNumberGenerator.GetBytes(512 / 8);

        var hash = KeyDerivation.Pbkdf2(
            request.Password,
            salt,
            KeyDerivationPrf.HMACSHA512,
            100_000,
            1024);

        var hashedPassword = Convert.ToBase64String(hash);

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Salt = salt,
            HashedPassword = hashedPassword,
            Age = request.Age,
            Created = DateTime.Now,
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        var claims = new List<Claim>()
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Email, user.Email),
        };

        return _tokenGenerator.GenerateToken(claims);
    }
}

public class RegistrationDto : IRequest<string>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
}

public class RegistationModelValidator : AbstractValidator<RegistrationDto>
{
    public RegistationModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(3).WithMessage("Min password length is 3");
        RuleFor(x => x.Age)
            .Must(a => a >= 18 && a < 200).WithMessage("Age should be >= 18 and lower than 200");
    }
}