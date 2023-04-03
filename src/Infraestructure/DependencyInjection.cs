using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Interfaces;
using Prome.Viaticos.Server.Infraestructure.Files;
using Prome.Viaticos.Server.Infraestructure.Maps;
using Prome.Viaticos.Server.Infraestructure.Persistence;
using Prome.Viaticos.Server.Infraestructure.Reports;
using Prome.Viaticos.Server.Infraestructure.Services;
using System.Reflection;

namespace Prome.Viaticos.Server.Infraestructure
{


    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(context =>
                context.UseSqlServer(
                    configuration.GetConnectionString("ApplicationConnection"),
                    config => config.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(Repository<>));

            services.AddScoped<IAsyncUnitOfWork, UnitOfWork>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddSingleton<IDateTime, DateTimeService>();

            services.AddSingleton<IFileService, FileService>();

            services.AddSingleton<IMapService, MapService>();

            services.AddSingleton<IEmailService, EmailService>();

            services.AddSingleton<IReportService, ReportService>();

            services.AddSingleton<IFtpService, FtpService>();

            services.AddSingleton<ICashFormToCalipsoService, CashFormToCalipsoService>();

            services.AddSingleton<IExpenseFormToCalipsoService, ExpenseFormToCalipsoService>();

            return services;
        }
    }
}
