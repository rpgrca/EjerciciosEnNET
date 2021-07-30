using System;
using System.Collections.Generic;

namespace BreakCamelCase.Logic
{
    public class Kata
    {
        public static string BreakCamelCase(string str)
        {
            var words = new List<string>();
            var index = 0;
            var lastIndex = 0;

            while ((index + 1 < str.Length) && (lastIndex = str.IndexOfAny("ABCDEFGHIKLMNOPQRSTUVWXYZ".ToCharArray(), index + 1)) > -1)
            {
                words.Add(str[index..lastIndex]);
                index = lastIndex;
            }

            words.Add(str[index..]);

            return string.Join(" ", words);
        }
    }
}
