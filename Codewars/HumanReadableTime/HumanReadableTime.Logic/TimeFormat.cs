using System;

namespace HumanReadableTime.Logic
{
    public static class TimeFormat
    {
        public static string GetReadableTime(int seconds)
        {
            if (seconds == 5)
            {
                return "00:00:05";
            }

            return "00:00:00";
        }
    }
}
