namespace YouGotChange.Logic;

public class Kata
{
    public static int[] GiveChange(int amount)
    {
        var change = new int[] { 0, 0, 0, 0, 0, 0 };
        change[5] = amount / 100;
        amount -= 100 * change[5];
        change[4] = amount / 50;
        amount -= 50 * change[4];
        change[3] = amount / 20;
        amount -= 20 * change[3];
        change[2] = amount / 10;
        amount -= 10 * change[2];
        change[1] = amount / 5;
        amount -= 5 * change[1];
        change[0] = amount;

        return change;
    }
}