using System;
using System.Diagnostics;

namespace ExtractImages.Extensions
{
    public static class ExceptionExtensions
    {
        public static void LogInfo(string message)
        {
            using (EventLog eventLog = new EventLog("System"))
            {
                eventLog.Source = "System";
                eventLog.WriteEntry(message, EventLogEntryType.Information);
            }
        }

        public static void LogWarning(string message)
        {
            using (EventLog eventLog = new EventLog("System"))
            {
                eventLog.Source = "Mortgage House";
                eventLog.WriteEntry(message, EventLogEntryType.Warning);
            }
        }

        public static void LogFailureAudit(string message)
        {
            using (EventLog eventLog = new EventLog("System"))
            {
                eventLog.Source = "System";
                eventLog.WriteEntry(message, EventLogEntryType.FailureAudit);
            }
        }

        public static void LogException(this Exception ex)
        {
            string message = string.Empty;
            if (ex.InnerException != null)
                message += $"{ex.InnerException.Message} \n {ex.InnerException.StackTrace}";
            else
                message += $"{ex.Message} \n {ex.StackTrace}";

            using (EventLog eventLog = new EventLog("System"))
            {
                eventLog.Source = "System";
                eventLog.WriteEntry(message, EventLogEntryType.Error);
            }
        }
    }

}
