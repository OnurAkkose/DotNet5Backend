using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.BackgroundJobs.Hangfire.Recurring
{
    public static class HangfireRecurring
    {
        [AutomaticRetry(Attempts = 0)]
        public static void InreaseProductPrice()
        {
            RecurringJob.RemoveIfExists(nameof(ProductJobsManager));
            RecurringJob.AddOrUpdate<ProductJobsManager>(nameof(ProductJobsManager),
               job => job.Process(), "50 23 * * *", TimeZoneInfo.Local);
        }
    }
}
