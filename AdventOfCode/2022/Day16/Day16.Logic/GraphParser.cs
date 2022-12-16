namespace Day16.Logic;

public class GraphParser
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly Dictionary<string, Valve> _pipeSystem;

    public int[][] Graph { get; private set; }
    private readonly Valve[] _valvesByIndex;
    public string[] Names { get; private set; }
    public int[] Flows { get; private set; }

    public GraphParser(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _pipeSystem = new Dictionary<string, Valve>();

        var order = 0;
        foreach (var line in _lines.Order())
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

        _valvesByIndex = _pipeSystem.Values.OrderBy(v => v.Order).ToArray();

        Names = _pipeSystem.Values.Select(v => v.Name).Order().ToArray();
        Flows = _pipeSystem.Values.Select(v => v.FlowRate).ToArray();
        Graph = new int[_pipeSystem.Count][];
        for (var index = 0; index < _pipeSystem.Count; index++)
        {
            Graph[index] = new int[_pipeSystem.Count];
        }

        for (var outer = 0; outer < Graph.Length; outer++)
        {
            for (var inner = 0; inner < Graph.Length; inner++)
            {
                if (inner == outer)
                {
                    Graph[outer][inner] = 0;
                    continue;
                }

                var outerValve = _valvesByIndex[outer];
                var innerValve = _valvesByIndex[inner];
                Graph[outer][inner] = Graph[inner][outer] = FindShortestPath(outerValve, innerValve);
            }
        }
    }

    private int FindShortestPath(Valve start, Valve end, int distance = 0)
    {
        int minimum = 10000;
        if (start.HasBeenVisited)
        {
            return minimum;
        }

        distance++;
        start.Visit();
        foreach (var connectedValve in start.ConnectedValves)
        {
            if (connectedValve.Order == end.Order)
            {
                start.Unvisit();
                return distance;
            }

            var result = FindShortestPath(connectedValve, end, distance);
            if (result < minimum)
            {
                minimum = result;
            }
        }

        start.Unvisit();
        return minimum;
    }
}