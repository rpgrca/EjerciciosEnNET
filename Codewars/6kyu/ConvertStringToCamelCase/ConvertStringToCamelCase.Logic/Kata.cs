namespace ConvertStringToCamelCase.Logic;

using System;
using System.Text.RegularExpressions;

public class Kata
{
    public static string ToCamelCase(string str)
    {
        var values = Regex.Split(str, "[-_]");
        return string.Concat(values[0], string.Concat(values[1..].Select(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase)));
    }
}