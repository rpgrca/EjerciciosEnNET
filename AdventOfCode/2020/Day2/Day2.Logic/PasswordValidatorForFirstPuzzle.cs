using System;
using System.Linq;

namespace AdventOfCode2020.Day2.Logic
{
    public class PasswordEntryParser
    {
        public PasswordEntry Parse(string rawEntry)
        {
            var rule = rawEntry.Split(":")[0];
            var range = rule.Split(" ")[0];
            var requiredLetter = rule.Split(" ")[1][0];
            var minimum = int.Parse(range.Split("-")[0]);
            var maximum = int.Parse(range.Split("-")[1]);
            var password = rawEntry.Split(":")[1].Trim();

            return new PasswordEntry(rule, range, password, requiredLetter, minimum, maximum);
        }
    }
}