namespace Day3.Logic;

public class Rucksack
{
    private string _input;

    public int SumOfPriorities { get; private set; }
    public int SumOfBadgePriorities { get; private set; } = 18;

    public Rucksack(string input)
    {
        _input = input;

        Parse();
    }

    private void Parse()
    {
        var sum = 0;
        var sumOfBadges = 0;
        var count = 0;
        string[] group = { "", "", "" };

        foreach (var line in _input.Split('\n'))
        {
            var length = line.Length / 2;
            var firstSection = line[0..length];
            var secondSection = line[length..];

            var repeatedItem = firstSection.Intersect(secondSection).Single();
            sum += GetPriority(repeatedItem);

            group[count++] = line;
            if (count > 2)
            {
                count = 0;
                var badge = group[0].Intersect(group[1]).Intersect(group[2]).Single();

                sumOfBadges += GetPriority(badge);
            }
        }

        SumOfPriorities = sum;
        SumOfBadgePriorities = sumOfBadges;
    }

    private int GetPriority(char item) =>
        (item & 0b00011111) + ((item & 0b00100000) == 0 ? 26 : 0);
}
