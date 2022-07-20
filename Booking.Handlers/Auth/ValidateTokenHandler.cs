using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Handlers.Auth;

public class ValidateTokenDto : IRequest<string?> { }

public class ValidateTokenHandler : IRequestHandler<ValidateTokenDto, string?>
{
    private readonly HttpContext _httpContext;

    public ValidateTokenHandler(IHttpContextAccessor contextAccessor)
    {
        _httpContext = contextAccessor.HttpContext;
    }

    public Task<string?> Handle(ValidateTokenDto request, CancellationToken cancellationToken)
    {
        if (!_httpContext.User.Identity.IsAuthenticated)
        {
            return Task.FromResult((string?)null);
        }

        return Task.FromResult(_httpContext.User.Identity.Name);
    }
}
