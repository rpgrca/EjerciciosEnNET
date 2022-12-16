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
            var others = new string(sections[1].AsSpan()[23..]);

            foreach (var other in others.Split(",").Select(o => o.Trim()))
            {
                _pipeSystem[valve].AddConnectedValve(_pipeSystem[other]);
            }
        }

/*
        _graph = new int[_pipeSystem.Count][];
        for (var index = 0; index < _graph.Length; index++)
        {
            _graph[index] = new int[_pipeSystem.Count];
        }*/

/*
        if (true)
        {*/
            var name = "AA";
            _elapsedTime = 0;

            for (var index = 0; index < _graph.Length; index++)
            {
                var distance = _graph[index][_namesToIndex[name]];
                if (distance > 0)
                {
                    var walker = new Walker(_indexToNames[index], _elapsedTime + distance, _pipeSystem, _graph, _namesToIndex, _indexToNames, _orderedFlow);
                    var pressure = walker.ReleasedPressure;
                    if (pressure > _maximumReleasedPressure)
                    {
                        _maximumReleasedPressure = pressure;
                    }

                    _pipeSystem[_indexToNames[index]].Close();
                }
            }
/*
            while (_elapsedTime <= 30)
            {
                var valve = GetClosestValve(name);
                if (valve.Name != name)
                {
                    _elapsedTime++;
                    valve.Open(_elapsedTime);
                    name = valve.Name;
                }
                else
                {
                    _elapsedTime++;
                }
            }
        }
        else
        {
            FindBestCombination();
        }

        _maximumReleasedPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure());
*/
    }

    private int ConvertNameToIndex(string name) =>
        _namesToIndex[name];

    private Valve GetClosestValve(string name)
    {
        var closestWeight = 10000;
        var closestIndex = 10000;
        var currentNode = ConvertNameToIndex(name);

        for (var index = 0; index < _graph.Length; index++)
        {
            if (_graph[currentNode][index] > 0)
            {
                if (! _pipeSystem[_indexToNames[index]].IsOpen)
                {
                    if (_graph[currentNode][index] <= closestWeight + 1)
                    {
                        if (closestWeight != 10000)
                        {
                            if (_orderedFlow[closestIndex] < _orderedFlow[index])
                            {
                                closestIndex = index;
                                closestWeight = _graph[currentNode][index];
                            }
                        }
                        else
                        {
                            if (_orderedFlow[index] > 0)
                            {
                                closestIndex = index;
                                closestWeight = _graph[currentNode][index];
                            }
                        }
                    }
                }
            }
        }

        if (closestIndex != 10000)
        {
            _elapsedTime += closestWeight;
            return _pipeSystem[_indexToNames[closestIndex]];
        }
        
        return _pipeSystem[name];
    }

    private void FindBestCombination()
    {
        _elapsedTime = 31;
        NavigateTo(_pipeSystem["AA"]);
    }

    private void NavigateTo(Valve valve)
    {
        _elapsedTime--;
        valve.Visit();

        if (_elapsedTime > 0)
        {
            if (!valve.IsOpen)
            {
                if (valve.FlowRate > 0)
                {
                    _elapsedTime--;
                    valve.Open(_elapsedTime);
                }
            }

            foreach (var otherValve in valve.ConnectedValves)
            {
                NavigateTo(otherValve);

                var totalReleasedPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure());
                if (totalReleasedPressure > _maximumReleasedPressure)
                {
                    _maximumReleasedPressure = totalReleasedPressure;
                }
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
