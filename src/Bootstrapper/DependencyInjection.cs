using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prome.Viaticos.Server.Application;
using Prome.Viaticos.Server.Infraestructure;

namespace Prome.Viaticos.Server.Bootstrapper
{

    public static class DependencyInjection
    {
        public static IServiceCollection AddBootstrapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfraestructure(configuration);

            return services;
        }
    }
}
