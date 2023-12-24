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

        public async Task<RegistrationDto> Registration(RegistrationDto registrationDto)
        {
            try
            {
                AppUser user = new AppUser()
                {
                    Name = registrationDto.Name,
                    UserName = registrationDto.Email,
                    Email = registrationDto.Email,
                    Year = registrationDto.Year,
                    Month = registrationDto.Month,
                    Day = registrationDto.Day,
                    Verified = false,
                    FollowerCount = 0,
                    FollowingCount = 0,
                    Bio = "",
                    Avatar = "truytrueuf"
                    
                };

                _logger.LogInformation("creating user");
                var result = await _userManager.CreateAsync(user, registrationDto.Password);

                if (!result.Succeeded)
                {
                    _logger.LogError("User creation failed for user with email: {userEmail}", user.Email);
                    return null;
                }

                _logger.LogInformation("User created successfully with email: {userEmail}", user.Email);
                _logger.LogInformation("Assigning user a role");
               // await _userManager.AddToRoleAsync(user, "User");

                return registrationDto;
            }
            catch (Exception)
            {

                return null;
            }

            

        }
    }
}
