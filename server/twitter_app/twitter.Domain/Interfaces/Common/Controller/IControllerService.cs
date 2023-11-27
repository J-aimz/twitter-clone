using AspNetCoreHero.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twitter.Domain.Interfaces.Common.Controller
{
    public interface IControllerService
    {
        IActionResult BadRequestResponse(string message);
        IActionResult ForbiddenResponse(string message);
        Task<IActionResult> Initiate<TOut>(Func<Task<IResult<TOut>>> action);
        Task<IActionResult> Initiate(Func<Task<IResult>> action);

        IActionResult ServerErrorResponse(string message);

    }
}
