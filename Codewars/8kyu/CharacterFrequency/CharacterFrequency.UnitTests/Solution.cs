namespace Solution;
using System.Collections.Generic;

public class Solution
{
    public static Dictionary<char, int> CharFreq(string message)
    {
        Dictionary<char, int> result = new Dictionary<char, int>();

        foreach (char c in message)
        {
            if (!result.ContainsKey(c)) { result[c] = 0; }
            ++result[c];
        }

        return result;
    }
}