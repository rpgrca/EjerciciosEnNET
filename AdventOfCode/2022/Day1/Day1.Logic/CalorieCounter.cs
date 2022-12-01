namespace Day1.Logic;
public class CalorieCounter
{
    private string _input;

    public int MostCaloriesCarriedBySingleElf { get; set; }

    public CalorieCounter(string input)
    {
        this._input = input;

        Parse();
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        var total = 0;
        var maximum = 0;

        foreach (var line in lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                if (total > maximum)
                {
                    maximum = total;
                }

                total = 0;
            }
            else
            {
                total += int.Parse(line);
            }
        }

        MostCaloriesCarriedBySingleElf = maximum;
    }
}