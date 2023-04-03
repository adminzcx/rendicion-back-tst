using Serilog;
using System;

namespace Prome.Viaticos.Server.Infraestructure.Logging
{
    public static class AppStaticLogInfraestucture
    {
        public static void Information(string message)
        {
            Log.Information(message);
        }

        public static void Fatal(Exception ex, string message)
        {
            Log.Fatal(ex, message);
        }

        public static void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }
    }
}
