namespace Day16.Logic;

public class PressureReleaseValve
{
    private string _input;

    public int FlowRate { get; set; }
    public int PressureRelease { get; set; }

    public PressureReleaseValve(string input)
    {
        _input = input;
    }

}
