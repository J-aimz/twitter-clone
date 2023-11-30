using twitter.API.Configurations.Interface;
using twitter.Domain.Interfaces.Common;
using twitter.Infrastructure.Common;

namespace twitter.API.Configurations.ServicesConfiguration
{
	public class ServicesConfig : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {           
            services.AddScoped<ICurrentUserService, CurrentUserService>();
						
		}
    }
}
