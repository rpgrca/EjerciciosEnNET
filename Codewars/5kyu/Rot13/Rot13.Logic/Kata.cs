namespace Rot13.Logic;

using System;

public class Kata
{
    public static string Rot13(string input)
    {
        var encrypted = string.Empty;
        foreach (var c in input)
        {
            if (char.IsLower(c))
            {
                encrypted += (char)((((c - 'a') + 13) % 26) + 'a');
            }
            else if (char.IsUpper(c))
            {
                encrypted += (char)((((c - 'A') + 13) % 26) + 'A');
            }
            else
            {
                encrypted += c;
            }
        }

        return encrypted;
    }
}