namespace InsertDashes.Logic;

public class Kata
{
    public static string InsertDash(int num)
    {
        var previous = 0;
        var result = string.Empty;
        foreach (var character in num.ToString())
        {
            var digit = character - '0';
            if (((previous & 1) == 1) && ((digit & 1) == 1))
            {
                result += "-";
            }

            previous = digit;
            result += character;
        }

        return result;
    }
}