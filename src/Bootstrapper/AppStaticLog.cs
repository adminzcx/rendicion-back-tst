using Prome.Viaticos.Server.Infraestructure.Logging;
using System;
namespace Prome.Viaticos.Server.Bootstrapper
{


    public static class AppStaticLog
    {
        public static void Information(string message)
        {
            AppStaticLogInfraestucture.Information(message);
        }

        public static void Fatal(Exception ex, string message)
        {
            AppStaticLogInfraestucture.Fatal(ex, message);
        }

        public static void CloseAndFlush()
        {
            AppStaticLogInfraestucture.CloseAndFlush();
        }
    }
}
