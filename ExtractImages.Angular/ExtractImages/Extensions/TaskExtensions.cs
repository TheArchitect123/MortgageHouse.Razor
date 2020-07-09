using System;
using System.Threading.Tasks;

namespace ExtractImages.Extensions
{
    public static class TaskExtensions
    {
        private static TimeSpan? DefaultTimeout = new TimeSpan(0, 0, 10);

        public static bool WaitUntilComplete(this Task task, TimeSpan? timeout)
        {
            TimeSpan? delay = timeout;
            if (!delay.HasValue)
                delay = DefaultTimeout.GetValueOrDefault();

            if (task == Task.Delay(delay.Value.Milliseconds))
                return true;

            return false;
        }
    }
}
