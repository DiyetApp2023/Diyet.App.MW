using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Appusion.Core.Common.Implementation.DbContexts;

namespace Appusion.Core.Common.IoC
{
    public static class DbContextInstaller
    {
        public static void InstallAppusionDietDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DietDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AppusionMSSQLConnectionString"));
            });
        }
    }
}
