using twitter.API.Configurations.Interface;
using twitter.Domain.Interfaces.Common;
using twitter.Domain.Interfaces.Repository;
using twitter.Infrastructure.Common;
using twitter.Infrastructure.Implementation;
using twitter.Infrastructure.Interface;
using twitter.Infrastructure.Repository;

namespace twitter.API.Configurations.ServicesConfiguration
{
	public  class ServicesConfig : IServiceInstaller
	{
		void IServiceInstaller.Install(IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped<ICurrentUserService, CurrentUserService>();
			services.AddScoped<IAuthentication, Authentication>();
		}
	}
}
