namespace DecipherThis.Logic;

using System;
using System.Text;

public class Kata
{
    public static string DecipherThis(string s)
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;

        var separator = string.Empty;
        var textBuilder = new StringBuilder();

        foreach (var value in s.Split(" "))
        {
            var number = string.Concat(value.TakeWhile(char.IsDigit));

            var decipherWord = value.Replace(number, $"{(char)int.Parse(number)}");
            if (decipherWord.Length > 2)
            {
                decipherWord = $"{decipherWord[0]}{decipherWord[^1]}{decipherWord[2..^1]}{decipherWord[1]}";
            }

            textBuilder.Append(separator);
            textBuilder.Append(decipherWord);
            separator = " ";
        }

        return textBuilder.ToString();
    }
}