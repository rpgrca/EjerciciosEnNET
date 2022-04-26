namespace JadenCasingStrings.Logic;

using System;
using System.Globalization;

public static class JadenCase
{
    public static string ToJadenCase(this string phrase) =>
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
}