using AspNetCoreHero.Results;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;
using twitter.API.Configurations.Interface;
using twitter.Application.Authentication.Command.Registration;
using twitter.Application.Home.Query;
using twitter.Infrastructure.Common.Behaviour;


namespace twitter.API.Configurations.ServicesConfiguration
{
	public class MediatorConfiguration : IServiceInstaller
	{
		void IServiceInstaller.Install(IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(RegistrationCommandHandler).Assembly));

			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}
	}
}
