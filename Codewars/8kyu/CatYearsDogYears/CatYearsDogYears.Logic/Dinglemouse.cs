namespace CatYearsDogYears.Logic;

public class Dinglemouse
{
    public static int[] HumanYearsCatYearsDogYears(int humanYears)
    {
        var value = 15 + (9 * (humanYears > 1 ? 1 : 0));

        return new int[]
        {
            humanYears,
            value + (4 * (humanYears > 2? humanYears - 2 : 0)),
            value + (5 * (humanYears > 2? humanYears - 2 : 0))
        };
    }
}