namespace CountTheDigit.Logic;

public class CountDig
{
    public static int NbDig(int n, int d)
    {
        var accumulator = 0;
        for (int index = 0; index <= n; index++)
        {
            var value = index * index;
            do
            {
                value = Math.DivRem(value, 10, out var leftover);
                if (leftover == d)
                {
                    accumulator++;
                }
            }
            while (value > 0);
        }

        return accumulator;
    }
}