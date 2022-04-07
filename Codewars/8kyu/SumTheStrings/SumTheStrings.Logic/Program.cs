using System;

namespace Solution
{
    public static class Program
    {
        public static string StringsSum(string s1, string s2)
        {
            _ = int.TryParse(s1, out int firstvalue);
            _ = int.TryParse(s2, out int secondValue);

            return (firstvalue + secondValue).ToString();
        }
    }
}