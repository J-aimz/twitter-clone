using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using twitter.Application.Authentication.Command.Registration;
using twitter.Domain.Dtos;

namespace twitter.API.Controllers
{
    
    public class AuthorizationController : ApiController
    {
        //props
        private readonly ILogger<AuthorizationController> _logger;

        //ctor
        public AuthorizationController(ILogger<AuthorizationController> logger) => _logger = logger;

        //mthds
        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(RegistrationDto registrationDto)
        {
            return await Initiate(() => Mediator.Send(new RegistrationCommand(registrationDto)));
        }

    }
}
