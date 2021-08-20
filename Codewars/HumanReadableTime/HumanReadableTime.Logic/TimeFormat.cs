using System;

namespace HumanReadableTime.Logic
{
    public static class TimeFormat
    {
        public static string GetReadableTime(int seconds)
        {
            return $"00:{seconds / 60:00}:{seconds % 60:00}";
        }
    }
}
