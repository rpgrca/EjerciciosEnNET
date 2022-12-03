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
            if (repeatedItem >= 'a' && repeatedItem <= 'z')
            {
                sum += repeatedItem - 'a' + 1;
            }
            else
            {
                sum += repeatedItem - 'A' + 27;
            }

            group[count++] = line;
            if (count > 2)
            {
                count = 0;
                var badge = group[0].Intersect(group[1]).Intersect(group[2]).Single();

                if (badge >= 'a' && badge <= 'z')
                {
                    sumOfBadges += badge - 'a' + 1;
                }
                else
                {
                    sumOfBadges += badge - 'A' + 27;
                }
            }
        }

        SumOfPriorities = sum;
        SumOfBadgePriorities = sumOfBadges;
    }
}
