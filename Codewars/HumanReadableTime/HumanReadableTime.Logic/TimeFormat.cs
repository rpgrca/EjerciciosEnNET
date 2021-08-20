namespace HumanReadableTime.Logic
{
    public static class TimeFormat
    {
        private const int SECONDS_PER_HOUR = 3600;
        private const int SECONDS_PER_MINUTE = 60;

        public static string GetReadableTime(int seconds)
        {
            var hours = seconds / SECONDS_PER_HOUR;
            var minutes = seconds % 3600 / SECONDS_PER_MINUTE;
            var leftovers = seconds % 60;

            return $"{hours:00}:{minutes:00}:{leftovers:00}";
        }
    }
}