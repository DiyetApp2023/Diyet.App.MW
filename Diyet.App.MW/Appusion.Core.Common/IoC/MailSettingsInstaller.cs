using Appusion.Core.Common.ParameterModels.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Appusion.Core.Common.IoC
{
    /// <summary>
    /// MailSettingsInstaller
    /// </summary>
    public static class MailSettingsInstaller
    {
        /// <summary>
        /// InstallMailSettings
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InstallMailSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var mailSettings = configuration.GetSection("MailSettings");
            services.Configure<MailSetting>(mailSettings);
        }
    }
}