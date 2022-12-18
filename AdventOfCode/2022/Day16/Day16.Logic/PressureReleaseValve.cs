namespace Day16.Logic;

public class PressureReleaseValve
{
    private readonly string _input;
    private readonly string[] _lines;
    private int _elapsedTime;
    private int _maximumReleasedPressure;
    private readonly Dictionary<string, Valve> _pipeSystem;
    private readonly Dictionary<string, int> _namesToIndex;

    private readonly int[][] _graph;

    private readonly int[] _orderedFlow;
    private readonly string[] _indexToNames;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public PressureReleaseValve(string input, int[][] graph, string[] orderedNodes, int[] orderedFlow)
    {
        _input = input;
        _lines = input.Split("\n");
        _elapsedTime = 0;
        _pipeSystem = new Dictionary<string, Valve>();
        _graph = graph;
        _namesToIndex = orderedNodes.Select((p, i) => new { p, i }).ToDictionary(a => a.p, a => a.i);
        _indexToNames = orderedNodes;
        _orderedFlow = orderedFlow;

        var order = 0;
        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var flowRate = int.Parse(sections[0].Split("=")[1]);
            _pipeSystem.Add(valve, new Valve(order++, valve, flowRate));
        }

        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var others = new string(sections[1].AsSpan()[23..]);

            foreach (var other in others.Split(",").Select(o => o.Trim()))
            {
                _pipeSystem[valve].AddConnectedValve(_pipeSystem[other]);
            }
        }

        var name = "AA";
        _elapsedTime = 0;

        for (var index = 0; index < _graph.Length; index++)
        {
            var distance = _graph[index][_namesToIndex[name]];
            if (distance > 0)
            {
                var walker = new Walker(_indexToNames[index], _elapsedTime + distance, _pipeSystem, _graph, _namesToIndex, _indexToNames, _orderedFlow, 30);
                var pressure = walker.ReleasedPressure;
                if (pressure > _maximumReleasedPressure)
                {
                    _maximumReleasedPressure = pressure;
                }

                _pipeSystem[_indexToNames[index]].Close();
            }
        }
    }
}

/*
public class PressureReleaseValve2
{
    private readonly string[] _lines;
    private int _elapsedTime;
    private int _maximumReleasedPressure;
    private readonly Dictionary<string, Valve> _pipeSystem;
    private readonly Dictionary<string, Valve> _pipeSystem2;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public PressureReleaseValve2(string input)
    {
        _lines = input.Split("\n");
        _elapsedTime = 0;
        _pipeSystem = new Dictionary<string, Valve>();
        _pipeSystem2 = new Dictionary<string, Valve>();

        var order = 0;
        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var flowRate = int.Parse(sections[0].Split("=")[1]);
            _pipeSystem.Add(valve, new Valve(order, valve, flowRate));
            _pipeSystem2.Add(valve, new Valve(order++, valve, flowRate));
        }

        foreach (var line in _lines)
        {
            var sections = line.Split(";");
            var valve = new string(line.AsSpan()[6..8]);
            var others = new string(sections[1].AsSpan()[23..]);

            foreach (var other in others.Split(",").Select(o => o.Trim()))
            {
                _pipeSystem[valve].AddConnectedValve(_pipeSystem[other]);
                _pipeSystem[valve].AddConnectedValve(_pipeSystem2[other]);
            }
        }

        var name = "AA";
        _elapsedTime = 0;
        for (var index = 0; index < _pipeSystem[name].ConnectedValves.Count - 1; index++)
        {
            var humanValve = _pipeSystem[name].ConnectedValves[index];
            for (var subIndex = index + 1; subIndex < _pipeSystem2[name].ConnectedValves.Count; subIndex++)
            {
                var elephantValve = _pipeSystem2[name].ConnectedValves[subIndex];

                var oldElapsedTime = _elapsedTime;
                _elapsedTime++;
                var walker = new Walker(humanValve, elephantValve, _elapsedTime, _pipeSystem, 30);

                var pressure = walker.ReleasedPressure;
                if (pressure > _maximumReleasedPressure)
                {
                    _maximumReleasedPressure = pressure;
                }

                elephantValve.Close();
                humanValve.Close();

                _elapsedTime = oldElapsedTime;

            }
        }


//        var name = "AA";
//        _elapsedTime = 0;
//
//        for (var index = 0; index < _pipeSystem[name].ConnectedValves.Count - 1; index++)
//        {
//            var humanValve = _pipeSystem[name].ConnectedValves[index];
//            for (var subIndex = index + 1; subIndex < _pipeSystem[name].ConnectedValves.Count; subIndex++)
//            {
//                var elephantValve = _pipeSystem[name].ConnectedValves[subIndex];
//
//                var oldElapsedTime = _elapsedTime;
//                _elapsedTime++;
//                var walker = new Walker2(humanValve, elephantValve, _elapsedTime, _pipeSystem, 30);
//
//                var pressure = walker.ReleasedPressure;
//                if (pressure > _maximumReleasedPressure)
//                {
//                    _maximumReleasedPressure = pressure;
//                }
//
//                elephantValve.Close();
//                humanValve.Close();
//
//                _elapsedTime = oldElapsedTime;
//            }
//        }
    }
}*/