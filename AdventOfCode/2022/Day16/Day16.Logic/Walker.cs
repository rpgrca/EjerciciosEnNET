namespace Day16.Logic;

public class Walker
{
    private int _elapsedTime;
    private readonly int _maximumReleasedPressure;
    private readonly Dictionary<string, Valve> _pipeSystem;
    private readonly Dictionary<string, int> _namesToIndex;

    private readonly int[][] _graph;
    private readonly int _maximumTime;
    private readonly int[] _orderedFlow;
    private readonly string _name;
    private readonly string[] _indexToNames;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public Walker(string fromNode, int elapsedTime, Dictionary<string, Valve> pipeSystem, int[][] graph, Dictionary<string, int> namesToIndex, string[] indexToNames, int[] orderedFlow, int maximumTime)
    {
        _elapsedTime = elapsedTime;
        _pipeSystem = pipeSystem;
        _graph = graph;
        _namesToIndex = namesToIndex;
        _indexToNames = indexToNames;
        _orderedFlow = orderedFlow;
        _maximumTime = maximumTime;
        _name = fromNode;

        if (_elapsedTime < maximumTime)
        {
            _elapsedTime++;
            pipeSystem[_name].Open(_elapsedTime);

            var pressure = BestPathFrom(_name);
            if (pressure > _maximumReleasedPressure)
            {
                _maximumReleasedPressure = pressure;
            }
        }
    }

    private int ConvertNameToIndex(string name) =>
        _namesToIndex[name];

    private int BestPathFrom(string name)
    {
        var maximumPressure = 0;
        var currentNode = ConvertNameToIndex(name);

        for (var index = 0; index < _graph.Length; index++)
        {
            var distance = _graph[currentNode][index];
            if (distance > 0)
            {
                var targetName = _indexToNames[index];
                if (!_pipeSystem[targetName].IsOpen && _pipeSystem[targetName].FlowRate > 0)
                {
                    var oldElapsedTime = _elapsedTime;
                    _elapsedTime += distance;

                    var walker = new Walker(targetName, _elapsedTime, _pipeSystem, _graph, _namesToIndex, _indexToNames, _orderedFlow, _maximumTime);
                    var pressure = walker.ReleasedPressure;
                    if (pressure > maximumPressure)
                    {
                        maximumPressure = pressure;
                    }

                    _elapsedTime = oldElapsedTime;
                    _pipeSystem[targetName].Close();
                }
            }
        }

        var currentPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure());
        return currentPressure > maximumPressure ? currentPressure : maximumPressure;
    }
}
