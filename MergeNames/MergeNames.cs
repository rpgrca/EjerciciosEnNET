using System;
using System.Linq;

namespace MergeNames.Logic;

public class MergeNames
{
    public static string[] UniqueNames(string[] names1, string[] names2) =>
        names1.Union(names2).Distinct().ToArray();
}
