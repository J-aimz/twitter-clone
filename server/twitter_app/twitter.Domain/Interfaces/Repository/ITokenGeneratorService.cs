using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using twitter.Domain.Models;

namespace twitter.Domain.Interfaces.Repository
{
	public interface ITokenGeneratorService
	{
		Task<string> GenerateTokenAsync(AppUser user);
		ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
		JwtSecurityToken ReadToken(string token);
	}
}
