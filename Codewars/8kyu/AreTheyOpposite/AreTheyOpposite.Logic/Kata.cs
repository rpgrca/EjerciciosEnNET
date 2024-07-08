namespace AreTheyOpposite.Logic;

public class Kata
{
  public static bool IsOpposite(string s1, string s2)
  {
    if (s1.Length == 0 || s2.Length == 0) return false;
    if (s1.Length != s2.Length) return false;

    for (var index = 0; index < s1.Length; index++) {
        if (s1[index] != s2[index]) {
            if (char.ToUpper(s1[index]) == char.ToUpper(s2[index])) {
                continue;
            }
        }

        return false;
    }
    
    return true;
  }
}