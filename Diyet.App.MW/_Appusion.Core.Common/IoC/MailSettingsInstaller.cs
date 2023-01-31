using Appusion.Core.Common.Implementation.DbContexts;
using Appusion.Core.Common.ParameterModels.Email;
using Appusion.Core.Common.ParameterModels.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appusion.Core.Common.IoC
{
    public static class MailSettingsInstaller
    {
        public static void InstallMailSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var mailSettings = configuration.GetSection("MailSettings");
            services.Configure<MailSetting>(mailSettings);
        }
    }
}
