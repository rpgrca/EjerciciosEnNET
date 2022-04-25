namespace CreditCardMask.Logic;

using System.Text.RegularExpressions;

public static class Kata
{
    // return masked string
    public static string Maskify(string cc)
    {
        if (cc.Length < 4) return cc;
        return $"{new string('#', cc.Length - 4)}{cc[^4..]}";
    }
}