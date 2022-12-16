namespace Day16.Logic;

public class Walker
{
    private int _elapsedTime;
    private int _maximumReleasedPressure;
    private readonly Dictionary<string, Valve> _pipeSystem;
    private readonly Dictionary<string, int> _namesToIndex;

    private readonly int[][] _graph;

    private readonly int[] _orderedFlow;
    private readonly string _name;
    private readonly string[] _indexToNames;

    public int FlowRate =>
        _pipeSystem.Where(p => p.Value.IsOpen).Sum(p => p.Value.FlowRate);

    public int ReleasedPressure => _maximumReleasedPressure;

    public Walker(string fromNode, int elapsedTime, Dictionary<string, Valve> pipeSystem, int[][] graph, Dictionary<string, int> namesToIndex, string[] indexToNames, int[] orderedFlow)
    {
        _elapsedTime = elapsedTime;
        _pipeSystem = pipeSystem;
        _graph = graph;
        _namesToIndex = namesToIndex;
        _indexToNames = indexToNames;
        _orderedFlow = orderedFlow;
        _name = fromNode;

        if (_elapsedTime < 30)
        {
            _elapsedTime++;
            pipeSystem[_name].Open(_elapsedTime);

            BestPathFrom(_name);
        }

        _maximumReleasedPressure = _pipeSystem.Sum(p => p.Value.GetReleasedPressure());
    }

    private int ConvertNameToIndex(string name) =>
        _namesToIndex[name];

    private int BestPathFrom(string name)
    {
        var currentNode = ConvertNameToIndex(name);
        var maximumPressure = int.MinValue;

        for (var index = 0; index < _graph.Length; index++)
        {
            var distance = _graph[currentNode][index];
            if (distance > 0)
            {
                var targetName = _indexToNames[index];
                if (!_pipeSystem[targetName].IsOpen)
                {
                    _elapsedTime += distance;
                    _elapsedTime += 1;
                    _pipeSystem[targetName].Open(_elapsedTime);

                    var walker = new Walker(targetName, _elapsedTime, _pipeSystem, _graph, _namesToIndex, _indexToNames, _orderedFlow);
                    var pressure = walker.ReleasedPressure;
                    if (pressure > maximumPressure)
                    {
                        maximumPressure = pressure;
                    }

                    _elapsedTime -= distance;
                    _elapsedTime -= 1;
                    _pipeSystem[targetName].Close();
                }
            }
        }

        return maximumPressure;
    }
}
