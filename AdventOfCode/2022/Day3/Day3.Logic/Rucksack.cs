namespace Day3.Logic;

public class Rucksack
{
    private string _input;

    public int SumOfPriorities { get; set; }

    public Rucksack(string input)
    {
        _input = input;

        Parse();
    }

    private void Parse()
    {
        var sum = 0;
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
        }

        SumOfPriorities = sum;
    }
}
