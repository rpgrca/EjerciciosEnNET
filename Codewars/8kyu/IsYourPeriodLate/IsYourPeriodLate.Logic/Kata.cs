namespace IsYourPeriodLate.Logic;

public static class Kata
{
  public static bool PeriodIsLate(DateTime last, DateTime today, int cycleLength)
  {
    return today.Subtract(last).Days > cycleLength;
  }
}