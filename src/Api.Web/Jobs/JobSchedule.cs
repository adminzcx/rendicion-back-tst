using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;

namespace Prome.Viaticos.Server.Api.Web.Jobs
{
    public class JobSchedule
    {
        public static async void StartAsync(IServiceProvider jobFactory)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            });
            var scheduler = await schedulerFactory.GetScheduler();
            scheduler.JobFactory = new FtpQuartzJobFactory(jobFactory);
            await scheduler.Start();

            IJobDetail ftpJob = JobBuilder.Create<FtpJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("JobFTPSchedule", "JobFTPSchedule")
                .StartNow()
                .WithSchedule(
                    SimpleScheduleBuilder.RepeatMinutelyForever(5))
                .Build();


            await scheduler.ScheduleJob(ftpJob, trigger);

        }
    }
}
