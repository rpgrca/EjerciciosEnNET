namespace Day13.Logic;

public class NumbersParser
{
    public INumber Values { get; }

    public NumbersParser(string value)
    {
        var (_, values) = Parse(value);
        Values = values;
    }

    private (int, INumber) Parse(string value)
    {
        var result = new Numbers();
        var index = 0;
        var number = string.Empty;

        for (; index < value.Length; index++)
        {
            if (value[index] == '[')
            {
                var (parsedCharacters, parsedNumbers) = Parse(value[(index + 1)..]);
                index += parsedCharacters + 1;
                result.Add(parsedNumbers);
            }
            else if (value[index] == ']')
            {
                if (! string.IsNullOrEmpty(number))
                {
                    result.Add(new Number(number));
                }

                return (index, result);
            }
            else
            {
                if (value[index] >= '0' && value[index] <= '9')
                {
                    number += value[index];
                }
                else
                {
                    if (! string.IsNullOrEmpty(number))
                    {
                        result.Add(new Number(number));
                        number = string.Empty;
                    }
                }
            }
        }

        return (index, result);
    }
}
