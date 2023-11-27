using MediatR;
using Microsoft.AspNetCore.Mvc;
using twitter.Application.Home.Query;
using twitter.Domain.Interfaces.Common.Exceptions;

namespace twitter.API.Controllers
{
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, IMediator mediator) 
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("/get-home")]
        public async Task<IActionResult> HomeTestQueryAsync()
        {
            var result =  await _mediator.Send(new HomeTestQuery());
            return Ok(result);
        }
    }
}
