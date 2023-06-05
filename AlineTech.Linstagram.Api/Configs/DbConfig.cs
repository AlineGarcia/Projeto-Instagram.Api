using Microsoft.EntityFrameworkCore;
using AlineTech.Linstagram.Api.Infra.Context;

namespace AlineTech.Linstagram.Api.Configs
{
    public static class DbConfig
    {
        public static IServiceCollection AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LinstagramContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }
    }
}
