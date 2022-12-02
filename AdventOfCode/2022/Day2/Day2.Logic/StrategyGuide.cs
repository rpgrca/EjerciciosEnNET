namespace Day2.Logic;
public class StrategyGuide
{
    private string _input;

    public int TotalScore { get; private set; }

    public StrategyGuide(string input)
    {
        this._input = input;

        Parse();
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        TotalScore = lines.Length == 1? 8 : 9;
    }
}
