namespace DecipherThis.Logic;

using System;

public class Kata
{
    public static string DecipherThis(string s)
    {
        if (string.IsNullOrEmpty(s)) return string.Empty;

        var decipheredText = new List<string>();
        foreach (var value in s.Split(" "))
        {
            var number = string.Concat(value.TakeWhile(char.IsDigit));
            var decipherWord = value.Replace(number, $"{(char)int.Parse(number)}");

            if (decipherWord.Length > 2)
            {
                decipherWord = $"{decipherWord[0]}{decipherWord[^1]}{decipherWord[2..^1]}{decipherWord[1]}";
            }

            decipheredText.Add(decipherWord);
        }

        return string.Join(" ", decipheredText);
    }
}