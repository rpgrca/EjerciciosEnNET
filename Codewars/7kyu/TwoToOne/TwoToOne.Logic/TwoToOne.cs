namespace TwoToOne.Logic;

public class TwoToOne
{
	public static string Longest (string s1, string s2)  =>
        string.Concat(s1.Union(s2).OrderBy(p => p).Distinct());
}
