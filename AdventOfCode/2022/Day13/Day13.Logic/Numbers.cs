namespace Day13.Logic;

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