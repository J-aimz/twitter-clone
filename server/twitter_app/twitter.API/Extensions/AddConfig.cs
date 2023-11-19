using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using twitter.Domain.Models;
using twitter.Infrastructure.DbContext;

namespace twitter.API.Extensions
{
    public static class AddConfig
    {
        public static void AddExtention(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextPool<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddIdentity<AppUser, IdentityRole<Guid>>(opt =>
            {
                opt.User.RequireUniqueEmail = true; 
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
