using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Prome.Viaticos.Server.Infraestructure.Logging
{
    public static class ConfigInfraestructure
    {
        public static IHostBuilder ConfigLoggingProviderInfraestructure(this IHostBuilder hostBuilder)
        {
            return hostBuilder
                .UseSerilog();
        }

        public static IApplicationBuilder UseRequestLoggingInfraestructure(this IApplicationBuilder app)
        {
            return app
                .UseSerilogRequestLogging();
        }

        public static void ConfigStaticLogInfraestructure(IConfigurationRoot configuration)
        {
            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .CreateLogger();
        }
    }
}
