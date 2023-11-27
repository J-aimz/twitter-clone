using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Interfaces.Common;
using twitter.Domain.Models;
using twitter.Infrastructure.DbContext;

namespace twitter.Infrastructure.Common
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public string? UserId { get; }
        public string? UserRole { get; }
        public string? UserEmail { get; }
        public string FullName { get; }
        public string? UserPhoneNumber { get; set; }

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            UserManager<AppUser> userManager,
            ApplicationDbContext context)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            UserRole = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
            UserEmail = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
            FullName = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName)
                       + " " + httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname);
            UserPhoneNumber = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.MobilePhone);
            _userManager = userManager;
            _context = context;
        }



    }
}
