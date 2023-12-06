using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;
using System.Reflection;
using twitter.API.Configurations.Interface;
using twitter.Application.Authentication.Command.Registration;
using twitter.Application.Home.Query;
using twitter.Domain.Models;

namespace twitter.API.Configurations.ServicesConfiguration
{
	public class MediatorConfiguration : IServiceInstaller
	{
		void IServiceInstaller.Install(IServiceCollection services, IConfiguration configuration)
		{
			 services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddTransient<IRequestHandler<HomeTestQuery, IResult<string>>, HomeTestQueryHandler>();
			//services.AddTransient<IRequestHandler<RegistrationCommand, IResult<AppUser>>>();
			
		}

	}
}
