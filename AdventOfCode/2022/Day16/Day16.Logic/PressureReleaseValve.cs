namespace Day16.Logic;

public record Valve
{
    private readonly List<Valve> _connectedValves;
    private int _from;

    public int FlowRate { get; private set; }
    public bool IsOpen { get; private set; }
    public string Name { get; private set; }
    public IEnumerable<Valve> ConnectedValves => _connectedValves;

    public Valve(string name, int flowRate)
    {
        Name = name;
        FlowRate = flowRate;
        IsOpen = false;
        _from = -1;
        _connectedValves = new List<Valve>();
    }

    public void AddConnectedValve(Valve valve) => _connectedValves.Add(valve);

    public void Open(int from)
    {
        IsOpen = true;
        _from = from;
    }

    public void Close()
    {
        IsOpen = false;
        _from = -1;
    }

    public int GetReleasedPressure() => _from > -1? _from * FlowRate : 0;
}

public class PressureReleaseValve
{
    private readonly string _input;
    private readonly string[] _lines;
    private int _timeLeft;
    private int _maximumReleasedPressure;
    private readonly Dictionary<string, Valve> _pipeSystem;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public PressureReleaseValve(string input)
    {
        _input = input;
        _lines = input.Split("\n");
        _timeLeft = 30;
        _pipeSystem = new Dictionary<string, Valve>();

        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var flowRate = int.Parse(sections[0].Split("=")[1]);
            _pipeSystem.Add(valve, new Valve(valve, flowRate));
        }

        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var others = new string(sections[1].AsSpan()[24..]);

            foreach (var other in others.Split(",").Select(o => o.Trim()))
            {
                _pipeSystem[valve].AddConnectedValve(_pipeSystem[other]);
            }
        }

        FindBestCombination();
    }

    private void FindBestCombination()
    {
        _timeLeft = 31;
        NavigateTo(_pipeSystem["AA"]);
    }

    private void NavigateTo(Valve valve)
    {
        _timeLeft--;
        if (_timeLeft > 0)
        {
            if (!valve.IsOpen)
            {
                if (valve.FlowRate > 0)
                {
                    _timeLeft--;
                    valve.Open(_timeLeft);
                }
                else
                {
                    foreach (var otherValve in valve.ConnectedValves)
                    {
                        NavigateTo(otherValve);
                    }
                }
            }
            else
            {
                foreach (var otherValve in valve.ConnectedValves)
                {
                    NavigateTo(otherValve);
                }
            }

            var totalReleasedPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure());
            if (totalReleasedPressure > _maximumReleasedPressure)
            {
                _maximumReleasedPressure = totalReleasedPressure;
            }
        }
        else
        {
            var totalReleasedPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure());
            if (totalReleasedPressure > _maximumReleasedPressure)
            {
                _maximumReleasedPressure = totalReleasedPressure;
            }
        }
    }
}
