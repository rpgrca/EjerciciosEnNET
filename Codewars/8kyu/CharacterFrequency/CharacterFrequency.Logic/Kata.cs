namespace CharacterFrequency.Logic;

using System.Collections.Generic;

public class Kata
{
    public static Dictionary<char, int> CharFreq(string message) =>
        message.GroupBy(t => t).ToDictionary(g => g.Key, g => g.Count());
}