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
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, IResult<RegistrationResponse>>
    {
        private readonly IAuthentication _auth;
        private readonly ILogger<RegistrationCommandHandler> _logger;

        public RegistrationCommandHandler(IAuthentication auth, ILogger<RegistrationCommandHandler> logger) 
        { 
            _auth = auth;
            _logger = logger;
        } 
        

        public async Task<IResult<RegistrationResponse>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                RegistrationDto registrationDto = new RegistrationDto()
                {
                    Name = request.Name,
                    Email = request.Email,  
                    Password = request.Password,
                    Year = request.Year,    
                    Month = request.Month,
                    Day = request.Day,
                };

                _logger.LogInformation("Registering a User");
                var result = await _auth.Registration(registrationDto);

                if (result is null) return Result<RegistrationResponse>.Fail("User registration failed!");
                //else if (result.Email != request.Email) return Result<RegistrationResponse>.Fail("Oops something went wrong we are working to fix it");

                var registrationResponse = new RegistrationResponse()
                {
                    Name = registrationDto.Name,
                    Email = registrationDto.Email,
                    Password = registrationDto.Password,
                    Year = registrationDto.Year,
                    Month = registrationDto.Month,
                    Day = registrationDto.Day,
                };
                 
                return Result<RegistrationResponse>.Success(registrationResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError("User registration failed with message: {msg} and source: {src} ", ex.Message, ex.StackTrace);
                return Result<RegistrationResponse>.Fail("Oops something went wrong we are working to fix it");
                throw;
            }
        }

	
	}
}
