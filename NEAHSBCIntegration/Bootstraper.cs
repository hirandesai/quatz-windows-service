using MyWindowsService.Jobs;
using Quartz;
using System;

namespace MyWindowsService
{
    public class Bootstraper
    {
        private IScheduler Scheduler { get; }

        public Bootstraper(IScheduler scheduler)
        {
            Scheduler = scheduler ?? throw new ArgumentNullException(nameof(scheduler));
        }

        public void OnStart()
        {
            IJobDetail transactionProcessingJob = JobBuilder
                                            .Create<ProcessPaymentJob>()
                                            .WithIdentity(nameof(ProcessPaymentJob), SchedulerConstants.DefaultGroup)
                                            .Build();

            ITrigger transactionTrigger = TriggerBuilder
                                .Create()
                                .WithIdentity($"{nameof(ProcessPaymentJob)}Trigger", SchedulerConstants.DefaultGroup)
                                .ForJob(transactionProcessingJob)
                                .WithCronSchedule("CRON EXPRESSION")
                                .Build();
            Scheduler.ScheduleJob(transactionProcessingJob, transactionTrigger);

            Scheduler.Start();
        }

        public void OnPaused() => Scheduler.PauseAll();

        public void OnContinue() => Scheduler.ResumeAll();

        public void OnStop() => Scheduler.Shutdown();
    }
}