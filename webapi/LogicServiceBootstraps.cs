using Microsoft.Extensions.DependencyInjection.Extensions;
using Service.Interfaces;
using Service.Services;

namespace webapi
{
    public static class LogicServiceBootstraps
    {
        public static IServiceCollection AddLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddScoped<ITest, Test>();
            return services;
        }
    }
}
