namespace Day13.Logic;

public interface INumber
{
    int Compare(INumber other);
}

public class Number : INumber
{
    private readonly int _value;

    public Number(string value) => _value = int.Parse(value);

    public int Compare(INumber other)
    {
        if (other is Number number)
        {
            return _value - number._value;
        }
        else
        {
            var numbers = new Numbers(this);
            return numbers.Compare(other);
        }
    }
}

public class Numbers : INumber
{
    private readonly List<INumber> _members;

    public Numbers() =>
        _members = new List<INumber>();

    public Numbers(INumber number) =>
        _members = new List<INumber> { number };

    public INumber Item(int index) => _members[index];

    public void Add(INumber number) => _members.Add(number);

    public int Compare(INumber other)
    {
        if (other is Number number)
        {
            var numbers = new Numbers(number);
            return Compare(numbers);
        }
        else
        {
            var numbers = (Numbers)other;
            var minimum = _members.Count < numbers._members.Count ? _members.Count : numbers._members.Count;
            for (var index = 0; index < minimum; index++)
            {
                var result = Item(index).Compare(numbers.Item(index));
                if (result != 0)
                {
                    return result;
                }
            }

            return _members.Count - numbers._members.Count;
        }
    }
}

public class NumbersParser
{
    public INumber Values { get; }

    public NumbersParser(string value)
    {
        var (parsedCharacters, values) = Parse(value);
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
                index += parsedCharacters;
                result.Add(parsedNumbers);
            }
            else if (value[index] == ']')
            {
                if (! string.IsNullOrEmpty(number))
                {
                    result.Add(new Number(number));
                    number = string.Empty;
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

public class DistressSignalDecoder
{
    public int SumOfCorrectIndexes { get; set; }

    public DistressSignalDecoder(string input)
    {
        SumOfCorrectIndexes = 0;

        var lines = input.Split("\n");
        var numbersAbove = new NumbersParser(lines[0]).Values;
        var numbersBelow = new NumbersParser(lines[1]).Values;

        if (numbersAbove.Compare(numbersBelow) < 0)
        {
            SumOfCorrectIndexes += 1;
        }
    }
}
