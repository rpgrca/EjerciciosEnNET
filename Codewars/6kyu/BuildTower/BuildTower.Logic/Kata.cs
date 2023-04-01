using System.Text;

namespace BuildTower.Logic;

public class Kata
{
  public static string[] TowerBuilder(int nFloors)
  {
    var result = new List<string>();

    for (var index = 0; index < nFloors; index++)
    {
      var spacing = new string(' ', nFloors - index - 1);
      result.Add($"{spacing}{new string('*', index * 2 + 1)}{spacing}");
    }

    return result.ToArray();
  }
}