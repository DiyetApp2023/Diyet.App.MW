using Appusion.Core.Common.ParameterModels.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Appusion.Core.Common.IoC
{
    public static class JwtParameterInstaller
    {
        /// <summary>
        /// InstallJwtParameters
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InstallJwtParameters(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtParametersSection = configuration.GetSection("JwtParameters");
            services.Configure<JwtParameter>(jwtParametersSection);
        }
    }
}
