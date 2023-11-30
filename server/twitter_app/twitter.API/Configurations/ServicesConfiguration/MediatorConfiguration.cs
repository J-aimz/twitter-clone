using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;
using System.Reflection;
using twitter.API.Configurations.Interface;
using twitter.Application.Home.Query;

namespace twitter.API.Configurations.ServicesConfiguration
{
	public class MediatorConfiguration : IServiceInstaller
	{
		void IServiceInstaller.Install(IServiceCollection services, IConfiguration configuration)
		{
			 services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

			services.AddTransient<IRequestHandler<HomeTestQuery, IResult<string>>, HomeTestQueryHandler>();
			
		}

	}
}
