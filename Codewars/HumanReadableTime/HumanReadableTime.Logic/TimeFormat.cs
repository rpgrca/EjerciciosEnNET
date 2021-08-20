using System;

namespace HumanReadableTime.Logic
{
    public static class TimeFormat
    {
        public static string GetReadableTime(int seconds)
        {
            return $"00:00:0{seconds}";
        }
    }
}
