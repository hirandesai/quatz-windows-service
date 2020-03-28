using Quartz;
using System;
using System.Threading.Tasks;

namespace MyWindowsService.Jobs
{
    [DisallowConcurrentExecution]
    public class ProcessPaymentJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            //... Process Payment code ...
            await Task.CompletedTask;
        }
    }
}
