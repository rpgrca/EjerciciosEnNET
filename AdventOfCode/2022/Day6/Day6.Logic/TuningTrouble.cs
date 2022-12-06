namespace Day6.Logic;

public class TuningTrouble
{
    private readonly string _input;
    private readonly int _length;
    private int _index;
    private bool _found;
    private string _uniqueSequence;

    public int ProcessedLength { get; set; }

    public TuningTrouble(string input, int length)
    {
        _input = input;
        _length = length;
        _uniqueSequence = "";

        ProcessedLength = -1;

        Parse();
    }

    private void Parse()
    {
        for (var index = 0; index < _input.Length && !_found; index++)
        {
            _index = index;
            FindUniqueString();
        }

        if (ProcessedLength == -1)
        {
            throw new Exception("Could not find start of packet");
        }
    }

    private void FindUniqueString()
    {
        var character = _input[_index];
        if (! _uniqueSequence.Contains(character))
        {
            _uniqueSequence += character;
            if (_uniqueSequence.Length >= _length)
            {
                ProcessedLength = _index + 1;
                _found = true;
            }
        }
        else
        {
            var repeatedCharacter = _uniqueSequence.IndexOf(character);
            _uniqueSequence = _uniqueSequence[(repeatedCharacter + 1)..] + character;
        }
    }
}