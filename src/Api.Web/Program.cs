using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Prome.Viaticos.Server.Bootstrapper;
using System;

namespace Prome.Viaticos.Server.Api.Web
{

    public class Program
    {


        public static int Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json")
           .Build();

            Config.ConfigStaticLog(configuration);

            try
            {
                AppStaticLog.Information("Starting web host");
                CreateHostBuilder(args).Build().Run();
                return 0;
            }
            catch (Exception ex)
            {
                AppStaticLog.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                AppStaticLog.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>

             Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigLoggingProvider();
    }
}
