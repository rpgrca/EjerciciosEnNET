namespace Day25.Logic;

public class SnafuConverter
{
    private long _input;
    public string Value { get; }

    public SnafuConverter(long input)
    {
        _input = input;
        Func<long, (string, int)> conversor = r => r switch
        {
            0 => ("0", 0),
            1 => ("1", 0),
            2 => ("2", 0),
            3 => ("=", 1),
            4 => ("-", 1)
        };

        Value = string.Empty;
        while (input > 0)
        {
            var result = conversor(input % 5L);
            Value = result.Item1 + Value;
            input = (input - (input % 5L)) / 5 + result.Item2;
        }

    }
}
