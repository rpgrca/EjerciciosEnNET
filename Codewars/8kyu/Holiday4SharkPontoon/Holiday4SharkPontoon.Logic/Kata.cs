namespace Holiday4SharkPontoon.Logic;

public class Kata
{
    public static string Shark(int pontoonDistance, int sharkDistance, int yourSpeed, int sharkSpeed, bool dolphin) =>
        sharkDistance / (float)sharkSpeed < pontoonDistance / (float)yourSpeed / (dolphin? 2 : 1)
            ? "Shark Bait!"
            : "Alive!";
}