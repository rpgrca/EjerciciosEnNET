/*
namespace Day16.Logic;

public class Act
{
    private readonly Valve _valve;
    private int _elapsedTime;
    private int _maximumReleasedPressure;
    private readonly Dictionary<string, Valve> _pipeSystem;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public Act(Valve valve, int elapsedTime, Dictionary<string, Valve> pipeSystem)
    {
        _valve = valve;
        _elapsedTime = elapsedTime;
        _pipeSystem = pipeSystem;
    }

    public Valve Execute()
    {
        if (! _valve.IsOpen && _valve.FlowRate > 0)
        {
            _valve.Open(_elapsedTime);
            return _valve;
        }
        else
        {
            foreach (var connectedValve in _valve.ConnectedValves)
            {
                if (connectedValve)
                return connectedValve;
            }
        }
    }

    private int BestPathFromHere()
    {
        var maximumPressure = 0;

        for (var index = 0; index < _humanValve.ConnectedValves.Count; index++)
        {
            var humanValve = _humanValve.ConnectedValves[index];
            for (var subIndex = 0; subIndex < _elephantValve.ConnectedValves.Count; subIndex++)
            {
                var elephantValve = _elephantValve.ConnectedValves[subIndex];
                var walker = new Walker2(humanValve, elephantValve, _elapsedTime, _pipeSystem, 26);

                var pressure = walker.ReleasedPressure;
                if (pressure > _maximumReleasedPressure)
                {
                    _maximumReleasedPressure = pressure;
                }

                elephantValve.Close();
                humanValve.Close();
            }
        }

        var currentPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure());
        return currentPressure > maximumPressure ? currentPressure : maximumPressure;
    }
}
*/