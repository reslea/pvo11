using Booking.Data;
using Booking.Data.Entities;
using Booking.Handlers.Utilities;
using FluentValidation;
using MediatR;
using System.Security.Claims;

namespace Booking.Handlers.Auth;

public class RegistrationHandler : IRequestHandler<RegistrationModel, string>
{
    private readonly IValidator<RegistrationModel> _validator;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly BookingDbContext _context;

    public RegistrationHandler(
        IValidator<RegistrationModel> validator,
        ITokenGenerator tokenGenerator,
        BookingDbContext context)
    {
        _validator = validator;
        _tokenGenerator = tokenGenerator;
        _context = context;
    }

    public async Task<string> Handle(RegistrationModel request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
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

public class RegistrationModel : IRequest<string>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
}

public class RegistationModelValidator : AbstractValidator<RegistrationModel>
{
    public RegistationModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(3).WithMessage("Min password length is 3");
        RuleFor(x => x.Age).Must(a => a > 18 && a < 200);
    }
}