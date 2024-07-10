namespace AreTheyOpposite.Logic;

public class Kata
{
  public static bool IsOpposite(string s1, string s2)
  {
    if (s1.Length == 0 || s2.Length == 0) return false;
    if (s1.Length != s2.Length) return false;

    return s1.Zip(s2).All(p => (p.First ^ p.Second) == 32);
  }
}