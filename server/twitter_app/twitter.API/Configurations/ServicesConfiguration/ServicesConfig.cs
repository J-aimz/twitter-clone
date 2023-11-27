using Microsoft.EntityFrameworkCore.Infrastructure;
using twitter.API.Configurations.Interface;
using twitter.Domain.Interfaces.Common;
using twitter.Domain.Interfaces.Common.Behaviour;
using twitter.Domain.Interfaces.Common.Controller;
using twitter.Domain.Interfaces.Common.Exceptions;
using twitter.Infrastructure.Common;
using twitter.Infrastructure.Common.Behaviour;
using twitter.Infrastructure.Common.Controller;
using twitter.Infrastructure.Common.Exceptions;

namespace twitter.API.Configurations.ServicesConfiguration
{
    public class ServicesConfig : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddMediatR(x => x.RegisterServicesFromAssembly(typeof(Program).Assembly));
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            //services.AddScoped<IControllerService, ControllerService>();
            //services.AddSingleton<IValidationException, ValidationBehavior>();
            //services.AddScoped<IValidationBehavior, ValidationBehavior>();
            //services.AddScoped<IValidationException, ValidationException>();
        }
    }
}
