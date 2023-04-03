using Quartz;
using Quartz.Spi;
using System;

namespace Prome.Viaticos.Server.Api.Web.Jobs
{
    public class FtpQuartzJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FtpQuartzJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;


        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _serviceProvider.GetService(bundle.JobDetail.JobType) as IJob;
        }

        public void ReturnJob(IJob job)
        {
            if (job is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}
