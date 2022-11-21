namespace NextPalindromicNumber.Logic;

public class Kata
{
    public static int NextPal(int value)
    {
        while ((++value).ToString() != string.Join("", value.ToString().Reverse()));
        return value;
    }
}
