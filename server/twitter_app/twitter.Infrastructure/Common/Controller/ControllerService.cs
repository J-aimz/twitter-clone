using AspNetCoreHero.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Interfaces.Common.Controller;
using twitter.Infrastructure.Common;
using twitter.Infrastructure.Common.Exceptions;

namespace twitter.Infrastructure.Common.Controller
{
    public class ControllerService : ControllerBase, IControllerService
    {
        private readonly ILogger<ControllerService> _logger;

        public ControllerService(ILogger<ControllerService> logger)
        {
            _logger = logger;
        }


        public IActionResult BadRequestResponse(string message)
        {
            return BadRequest(new Result<string> { Message = message });
        }

        public IActionResult ForbiddenResponse(string message)
        {
            return BadRequest(new Result<string> { Message = message });
        }


        public async Task<IActionResult> Initiate<TOut>(Func<Task<IResult<TOut>>> action)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetErrorsAsList(ModelState));

                var result = await action.Invoke();
                if (result.Succeeded)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequestResponse(ex.Message);
            }
            catch (ValidationBehavior ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequestResponse(string.Join('\n', ex.Errors));
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogError(ex, ex.Message);
                return ForbiddenResponse("Forbidden");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return ServerErrorResponse(Constants.InternalServerErrorMessage);
            }
        }

        public IActionResult ServerErrorResponse(string message)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, new Result<string> { Message = message });
        }

        public async Task<IActionResult> Initiate(Func<Task<IResult>> action)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(GetErrorsAsList(ModelState));

                var result = await action.Invoke();
                if (result.Succeeded)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequestResponse(ex.Message);
            }
            catch (ValidationBehavior ex)
            {
                _logger.LogError(ex, ex.Message);
                return BadRequestResponse(string.Join('\n', ex.Errors));
            }
            catch (ForbiddenAccessException ex)
            {
                _logger.LogError(ex, ex.Message);
                return ForbiddenResponse("Forbidden");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return ServerErrorResponse(Constants.InternalServerErrorMessage);
            }
        }

        public static List<string> GetErrorsAsList(ModelStateDictionary? modelState)
        {
            if (modelState == null || !modelState.Values.Any())
                return new List<string>();

            IList<string> allErrors = modelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage)).ToList();

            var err = allErrors.Where(error => !string.IsNullOrEmpty(error)).ToList();

            if (err.Count == 0)
                err = modelState.Values.SelectMany(v => v.Errors.Select(b => b.Exception.Message)).ToList();

            return err;
        }


    }
}
