namespace YouGotChange.Logic;

public class Kata
{
    public static int[] GiveChange(int amount)
    {
        var bills = new int[] { 100, 50, 20, 10, 5, 1 };
        var change = new int[] { 0, 0, 0, 0, 0, 0 };

        for (var position = 0; position < bills.Length; position++)
        {
            amount -= bills[position] * (change[bills.Length - 1 - position] = amount / bills[position]);
        }

        return change;
    }
}