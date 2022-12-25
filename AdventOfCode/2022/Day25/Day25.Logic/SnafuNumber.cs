namespace Day25.Logic;

public class SnafuNumber
{
    private string _input;

    public double Value { get; set; }

    public SnafuNumber(string input)
    {
        _input = input;

        var length = input.Length;
        for (var index = 0; index < length; index++)
        {
            Value = Value + Math.Pow(5, length - index - 1) * ConvertSnafuDigit(input[index]);
        }
    }

    private static double ConvertSnafuDigit(char digit) =>
        digit switch
        {
            '=' => -2,
            '-' => -1,
            '0' => 0,
            '1' => 1,
            _ => 2
        };
}