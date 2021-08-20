using System;

namespace HumanReadableTime.Logic
{
    public static class TimeFormat
    {
        public static string GetReadableTime(int seconds)
        {
            var hours = seconds / 3600;
            var minutes = seconds % 3600 / 60;
            var leftovers = seconds % 60;

            return $"{hours:00}:{minutes:00}:{leftovers:00}";
        }
    }
}
