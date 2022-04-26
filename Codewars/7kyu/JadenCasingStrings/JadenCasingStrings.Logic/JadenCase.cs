namespace JadenCasingStrings.Logic;

using System;
using System.Globalization;

public static class JadenCase
{
    public static string ToJadenCase(this string phrase) =>
        string.Join(" ", phrase.Split(" ").Select(p => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p)));
}