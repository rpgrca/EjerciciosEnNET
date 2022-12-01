namespace Day1.Logic;

using System.Linq;

public class CalorieCounter
{
    private string _input;

    public int MostCaloriesCarriedBySingleElf { get; set; }
    public int CaloriesCarriedByTopThreeElves { get; set; }

    public CalorieCounter(string input)
    {
        this._input = input;

        Parse();
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        var total = 0;
        var elves = new List<int>();

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                elves.Add(total);
                total = 0;
            }
            else
            {
                total += int.Parse(line);
            }
        }

        elves.Sort();
        MostCaloriesCarriedBySingleElf = elves[^1];
        CaloriesCarriedByTopThreeElves = elves[^1] + elves[^2] + elves[^3];
    }
}