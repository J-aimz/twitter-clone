using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Interfaces.Repository;
using twitter.Domain.Models;
using static System.Int32;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace twitter.Infrastructure.Repository
{
	public class TokenGeneratorService : ITokenGeneratorService
	{
		private readonly IConfiguration _configuration;
		private readonly UserManager<AppUser> _userManager;

		public TokenGeneratorService(IConfiguration configuration, UserManager<AppUser> userManager)
		{
			_configuration = configuration;
			_userManager = userManager;
		}


		public Task<string> GenerateTokenAsync(AppUser user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			var authClaims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			if (!string.IsNullOrWhiteSpace(user.Name))
				authClaims.Add(new Claim(ClaimTypes.GivenName, user.Name));

			var signingKey =
				new SymmetricSecurityKey(
					Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"] ?? string.Empty));
			TryParse(_configuration["JwtSettings:TokenValidityInMinutes"], out var tokenValidityInMinutes);

			// Specify JWTSecurityToken Parameters
			var token = new JwtSecurityToken
			(
				audience: _configuration["JwtSettings:Audience"],
				issuer: _configuration["JwtSettings:Issuer"],
				claims: authClaims,
				expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
				signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
			);

			return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
		}

		

		public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
		{
			var tokenValidationParameters = new TokenValidationParameters()
			{
				ValidateAudience = false,
				ValidateIssuer = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey =
					new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"] ?? string.Empty)),
				ValidateLifetime = false
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var principal =
				tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
			if (securityToken is not JwtSecurityToken jwtSecurityToken ||
				!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
					StringComparison.InvariantCultureIgnoreCase))
			{
				throw new SecurityTokenException("Invalid token");
			}

			return principal;
		}

		public JwtSecurityToken ReadToken(string token)
		{
			return new JwtSecurityTokenHandler().ReadJwtToken(token);
		}

	}
}
