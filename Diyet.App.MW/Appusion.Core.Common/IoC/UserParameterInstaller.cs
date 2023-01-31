using Appusion.Core.Common.ParameterModels.Email;
using Appusion.Core.Common.ParameterModels.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.IoC
{
    /// <summary>
    /// UserParameterInstaller
    /// </summary>
    public static class UserParameterInstaller
    {
        /// <summary>
        /// InstallUserParameters
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InstallUserParameters(this IServiceCollection services, IConfiguration configuration)
        {
            var userParameters = configuration.GetSection("UserParameters");
            services.Configure<UserParameter>(userParameters);
        }
    }
}
