namespace LegacyApp
{
    public class StandardClock : IClock
    {
        public DateTime Now => DateTime.Now;
    }
}