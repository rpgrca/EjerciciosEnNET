using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BreakCamelCase.Logic
{
    public class Kata
    {
        public static string BreakCamelCase(string str)
        {
            var words = new List<string>();
            var word = string.Empty;

            foreach (var character in str)
            {
                if (char.IsUpper(character))
                {
                    if (! string.IsNullOrEmpty(word))
                    {
                        words.Add(word);
                    }

                    word = character.ToString();
                }
                else
                {
                    word += character;
                }
            }

            words.Add(word);
            return string.Join(" ", words);
        }
    }
}
