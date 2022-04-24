namespace Solution;

using System;
using System.Collections.Generic;
using System.Linq;

public class Debug
{
    public static string DictionaryToJson(Dictionary<char, int> dict)
    {
        IEnumerable<string> entries = dict.OrderBy(x => (int)x.Key).Select(d =>
            String.Format("\"{0}\": [{1}]", d.Key, string.Join(",", d.Value)));
        return "{" + String.Join(",", entries) + "}";
    }
}
