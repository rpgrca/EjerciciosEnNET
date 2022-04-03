using System.Text.RegularExpressions;

namespace BreakCamelCase.Logic
{
    public static class Kata
    {
        public static string BreakCamelCase(string str) =>
            Regex.Replace(str, "([A-Z])", " $1").Trim();
    }
}
