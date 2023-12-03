using AspNetCoreHero.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Dtos;
using twitter.Domain.Interfaces.Repository;
using twitter.Domain.Models;

namespace twitter.Infrastructure.Repository
{
    public class Authentication : IAuthentication
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<Authentication> _logger;
        private readonly SignInManager<AppUser> _signInManager;


        public Authentication(UserManager<AppUser> userManager, ILogger<Authentication> logger, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager; 
            _logger = logger;
            _signInManager = signInManager;
        }

        public async Task<AppUser> Registration(RegistrationDto registrationDto)
        {
            if (registrationDto is null) return null;

            AppUser user = new AppUser()
            {
                UserName = registrationDto.Email,
                Email = registrationDto.Email,
                Year = registrationDto.Year,    
                Month = registrationDto.Month,
                Day = registrationDto.Day,  

            };

            _logger.LogInformation("creating user");
            var result = await _userManager.CreateAsync(user, registrationDto.Password);

            if (!result.Succeeded) 
            {
                _logger.LogError("User creation failed");
                return new AppUser();
            } 

            await _userManager.AddToRoleAsync(user, "User");

            return user;

        }
    }
}
