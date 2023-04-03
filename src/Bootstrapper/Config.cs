namespace Prome.Viaticos.Server.Bootstrapper
{
    using Infraestructure.Logging;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using LoggingInfraestructure = Infraestructure.Logging.ConfigInfraestructure;

    public static class Config
    {
        public static IHostBuilder ConfigLoggingProvider(this IHostBuilder hostBuilder)
        {
            return hostBuilder
                .ConfigLoggingProviderInfraestructure();
        }

        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
        {
            return app
                .UseRequestLoggingInfraestructure();
        }

        public static void ConfigStaticLog(IConfigurationRoot configuration)
        {
            LoggingInfraestructure.ConfigStaticLogInfraestructure(configuration);
        }
    }
}