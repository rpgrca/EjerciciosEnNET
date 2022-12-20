namespace Day20.Logic;
public class GrovePositioningSystemDecryptor
{
    private string _input;

    public IEnumerable<int> OriginalValues { get; set; }

    public GrovePositioningSystemDecryptor(string input)
    {
        _input = input;
        OriginalValues = _input.Split("\n").Select(p => int.Parse(p));
    }
}
