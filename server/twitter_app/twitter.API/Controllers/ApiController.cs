using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;


using System.Net;
using twitter.Domain.Interfaces.Common.Exceptions;
using Microsoft.AspNet.SignalR;
using twitter.Domain.Interfaces.Common.Controller;

namespace twitter.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[Controller]")]
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;
        private IMediator _mediator;
        private IControllerService _controllerService;
        //private IValidationException _validationException;


        //public ApiController(ILogger<ApiController> logger, IValidationException validationException, IControllerService controllerService) 
        //{ 
        //    _logger = logger; 
        //    _controllerService = controllerService;
        //    //_validationException = validationException; 
        //}
        

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected IActionResult BadRequestResponse(string message)
        {
            return _controllerService.BadRequestResponse(message);
        }

        protected IActionResult ForbiddenResponse(string message)
        {
            return _controllerService.ForbiddenResponse(message);
        }

        protected IActionResult ServerErrorResponse(string message)
        {
            return _controllerService.ServerErrorResponse(message);
        }

        protected async Task<IActionResult> Initiate<TOut>(Func<Task<IResult<TOut>>> action)
        {
            return await _controllerService.Initiate(action);
        }

        protected async Task<IActionResult> Initiate(Func<Task<AspNetCoreHero.Results.IResult>> action)
        {
            return await _controllerService.Initiate(action);

        }

    }
}
