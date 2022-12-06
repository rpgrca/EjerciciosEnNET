namespace Day6.Logic;

public class TuningTrouble
{
    private string _input;

    public TuningTrouble(string input)
    {
        this._input = input;

        throw new Exception("Could not find start of packet");
    }
}
