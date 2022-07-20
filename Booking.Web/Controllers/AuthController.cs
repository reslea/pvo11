using Booking.Data.Entities;
using Booking.Handlers.Auth;
using Booking.Services;
using Booking.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Booking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ValidateTokenAsync()
        {
            var username = await mediator.Send(new ValidateTokenDto());

            if (username == null)
            {
                return Unauthorized();
            }

            return Ok(username);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = await mediator.Send(new LoginDto { Login = model.Login, Password = model.Password });

                return Ok(new { token });
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        [HttpPost("register")]
        public IActionResult Register(RegistrationModel model)
        {
            try
            {
                var token = mediator.Send(model);

                return Ok(token);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
