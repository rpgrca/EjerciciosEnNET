﻿namespace LeapYears.Logic;

public class Kata
{
    public static bool IsLeapYear(int year) =>
        year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
}