namespace Holiday4SharkPontoon.Logic;

public class Kata
{
    public static string Shark(int pontoonDistance, int sharkDistance, int yourSpeed, int sharkSpeed, bool dolphin) =>
        pontoonDistance / (double)yourSpeed < sharkDistance * (dolphin? 2.0 : 1.0) / sharkSpeed
            ? "Alive!"
            : "Shark Bait!";
}