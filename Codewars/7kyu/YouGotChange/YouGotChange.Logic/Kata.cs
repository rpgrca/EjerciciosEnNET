namespace YouGotChange.Logic;

public class Kata
{
    public static int[] GiveChange(int amount)
    {
        var change = new Change.Builder().For(amount).Build();
        return change.OptimizedChange;
    }
}