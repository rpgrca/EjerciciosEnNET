namespace Day3.Logic;

public class Rucksack
{
    private readonly string _input;

    public int SumOfPriorities { get; private set; }
    public int SumOfBadgePriorities { get; private set; }

    public Rucksack(string input)
    {
        _input = input;

        Parse();
    }

    private void Parse()
    {
        var count = 0;
        string[] group = { "", "", "" };

        foreach (var line in _input.Split('\n'))
        {
            var sections = SplitInSections(line);
            var repeatedItem = GetRepeatedItem(sections);
            SumOfPriorities += GetPriority(repeatedItem);

            group[count++] = line;
            if (count > 2)
            {
                count = 0;
                repeatedItem = GetRepeatedItem(group);
                SumOfBadgePriorities += GetPriority(repeatedItem);
            }
        }
    }

    private static int GetPriority(char item) =>
        (item & 0b00011111) + ((item & 0b00100000) == 0 ? 26 : 0);

    private static char GetRepeatedItem(params string[] items)
    {
        IEnumerable<char> repeatedItems = items[0];
        foreach (var item in items[1..])
        {
            repeatedItems = repeatedItems.Intersect(item);
        }

        return repeatedItems.Single();
    }

    private static string[] SplitInSections(string line)
    {
        var length = line.Length / 2;
        var firstSection = line[0..length];
        var secondSection = line[length..];
        return new string[] { firstSection, secondSection };
    }
}