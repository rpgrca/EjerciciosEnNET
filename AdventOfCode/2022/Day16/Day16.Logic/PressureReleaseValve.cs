namespace Day16.Logic;

public class PressureReleaseValve
{
    private readonly string _input;
    private readonly string[] _lines;
    private int _timeLeft;

    public int FlowRate { get; set; }
    public int ReleasedPressure { get; set; }

    public PressureReleaseValve(string input)
    {
        _input = input;
        _lines = input.Split("\n");
        _timeLeft = 30;

        string valve = string.Empty;
        int flowRate = 0;
        string other = string.Empty;
        foreach (var line in _lines)
        {
            var sections = line.Split(";");
//Valve AA has flow rate=0; tunnels lead to valves BB
            valve = new string(line.AsSpan()[6..8]);
            flowRate = int.Parse(sections[0].Split("=")[1]);
            other = sections[1][24..];
        }

        _timeLeft--;
        FlowRate = flowRate;
        _timeLeft--;
        while (_timeLeft-- > 0)
        {
            ReleasedPressure += FlowRate; 
        }
    }
}
