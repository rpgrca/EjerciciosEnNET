namespace Day13.Logic;

public class NumbersParser
{
    private readonly string _value;

    public INumber Values { get; }

    public NumbersParser(string value)
    {
        _value = value;
        var (_, values) = Parse(0);
        Values = values;
    }

    private (int, INumber) Parse(int start)
    {
        var result = new Numbers();
        var number = string.Empty;
        var index = start;

        for (; index < _value.Length; index++)
        {
            switch (_value[index])
            {
                case '[':
                    var (parsedCharacters, parsedNumbers) = Parse(index + 1);
                    index += parsedCharacters;
                    result.Add(parsedNumbers);
                    break;

                case ']':
                    if (! string.IsNullOrEmpty(number))
                    {
                        result.Add(new Number(number));
                    }
                    return (index, result);

                case >= '0' and <= '9':
                    number += _value[index];
                    break;

                default:
                    if (! string.IsNullOrEmpty(number))
                    {
                        result.Add(new Number(number));
                        number = string.Empty;
                    }
                    break;
            }
        }

        return (index, result);
    }
}