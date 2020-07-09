using System;

namespace ExtractImages.Extensions
{
    public static class DateTimeExtensions
    {
        public static string DateToStandard(this DateTime date) => date.ToString("dd MMM");
        public static string TimeToStandard(this DateTime date) => $"{date.ToString("hh:mm")} {date.ToString("tt")}";
    }

}
