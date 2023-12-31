﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using twitter.API.Configurations.Interface;

namespace twitter.API.Configurations.ServicesConfiguration
{
	public class JwtConfiguration : IServiceInstaller
	{
		public void Install(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<DataProtectionTokenProviderOptions>(options =>
			{
				options.TokenLifespan = TimeSpan.FromMinutes(5);
			});

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.User.RequireUniqueEmail = true;
			});

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{
				options.RequireHttpsMetadata = false;
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = configuration["JwtSettings:Issuer"],
					ValidAudience = configuration["JwtSettings:Audience"],
					IssuerSigningKey =
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
					ClockSkew = TimeSpan.Zero
				};
			});

			services.AddAuthorization();
		}
	}
}
