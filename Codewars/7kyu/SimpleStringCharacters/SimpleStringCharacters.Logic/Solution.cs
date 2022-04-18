namespace SimpleStringCharacters.Logic;

using System;

public class Solution
{
    public static int [] Solve(string s)
    {
        var uppercase = 0;
        var lowercase = 0;
        var numbers = 0;
        var special = 0;

        foreach (var c in s)
        {
            if (char.IsUpper(c))
            {
                uppercase++;
            }
            else if (char.IsLower(c))
            {
                lowercase++;
            }
            else if (char.IsDigit(c))
            {
                numbers++;
            }
            else
            {
                special++;
            }
        }

        return new int[] { uppercase, lowercase, numbers, special };
    }
}