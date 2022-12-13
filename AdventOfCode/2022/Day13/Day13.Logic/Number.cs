namespace Day13.Logic;

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
