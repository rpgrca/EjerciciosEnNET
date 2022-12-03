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
        var length = _input.Length / 2;
        var firstSection = _input[0..length];
        var secondSection = _input[length..];

        var repeatedItem = firstSection.Intersect(secondSection).Single();
        if (repeatedItem >= 'a' && repeatedItem <= 'z')
        {
            sum = repeatedItem - 'a' + 1;
        }
        else
        {
            sum = repeatedItem - 'A' + 27;
        }

        SumOfPriorities = sum;
    }
}
