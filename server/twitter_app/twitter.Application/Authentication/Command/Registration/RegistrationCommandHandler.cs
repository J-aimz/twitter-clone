using AspNetCoreHero.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Owin.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Dtos;
using twitter.Domain.Interfaces.Repository;
using twitter.Domain.Models;

namespace twitter.Application.Authentication.Command.Registration
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, IResult<AppUser>>
    {
        private readonly IAuthentication _auth;
        private readonly ILogger<RegistrationCommandHandler> _logger;

        public RegistrationCommandHandler(IAuthentication auth, ILogger<RegistrationCommandHandler> logger) 
        { 
            _auth = auth;
            _logger = logger;
        } 
        

        public async Task<IResult<AppUser>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                RegistrationDto registrationDto = new RegistrationDto()
                {
                    Email = request.Email,  
                    Password = request.Password,
                    Year = request.Year,    
                    Month = request.Month,
                    Day = request.Day,
                };

                _logger.LogInformation("Registering a User");
                var result = await _auth.Registration(registrationDto);

                if (result is null) return Result<AppUser>.Fail("Oops something went wrong we are working to fix it");
                else if (result.Email != request.Email) return Result<AppUser>.Fail("Oops something went wrong we are working to fix it");

                return Result<AppUser>.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("User registration failed with message: {msg} and source: {src} ", ex.Message, ex.StackTrace);
                return Result<AppUser>.Fail("Oops something went wrong we are working to fix it");
                throw;
            }
        }
    }
}
