using Booking.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthcheckController : ControllerBase
    {
        private readonly IMediator mediator;

        public HealthcheckController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("ping")]
        public async Task<IActionResult> GetPing()
        {
            var response = await mediator.Send(new Ping());

            return Ok(response);
        }
    }
}
