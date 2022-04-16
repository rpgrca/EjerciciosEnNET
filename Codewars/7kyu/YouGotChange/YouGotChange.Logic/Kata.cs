namespace YouGotChange.Logic;

public class Kata
{
    public static int[] GiveChange(int amount)
    {
        var bills = new int[] { 100, 50, 20, 10, 5, 1 };
        var change = new Change(amount, bills);
        return change.OptimizedChange;
    }
}