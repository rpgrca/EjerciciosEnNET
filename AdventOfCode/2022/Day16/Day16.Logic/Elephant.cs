namespace Day16.Logic;

public class Elephant
{
    public enum ScavengeActions
    {
        Move,
        Open,
        Rest
    }

    private Valve _location;
    private Valve? _target;
    private readonly Dictionary<string, Valve> _pipeSystem;
    private readonly int[][] _graph;
    private readonly string[] _indexToName;
    private readonly Valve _originalLocation;
    private int _when;
    private int _routeIndex;
    private ScavengeActions _action;
    private List<int> _route;
    private readonly List<List<int>> _routes;
    private string _currentPlan;

    public ScavengeActions Action => _action;

    public Elephant(Valve location, Dictionary<string, Valve> pipeSystem, int[][] graph, string[] indexToName, int routeIndex, List<List<int>> routes)
    {
        _location = _originalLocation = location;
        _pipeSystem = pipeSystem;
        _graph = graph;
        _indexToName = indexToName;
        _routes = routes;

        ResetFor(routeIndex);
    }

    public void ResetFor(int routeIndex)
    {
        _location = _originalLocation;
        _action = ScavengeActions.Move;
        _currentPlan = string.Empty;
        _when = 0;
        _routeIndex = 0;
        _route = _routes[routeIndex];
    }

    public void Act(int elapsedTime, HashSet<int> visitedValves)
    {
        if (elapsedTime == _when)
        {
            switch (_action)
            {
                case ScavengeActions.Move:
                    _action = ScavengeActions.Open;

                    var distance = DistanceToNextValve(visitedValves);
                    if (distance == 0)
                    {
                        _action = ScavengeActions.Rest;
                    }
                    else
                    {
                        _when += distance;
                    }
                    break;

                case ScavengeActions.Open:
                    _location = _target!;
                    _location.Open(_when);
                    _action = ScavengeActions.Move;
                    _when += 1;
                    break;
            }
        }
    }

    private int DistanceToNextValve(HashSet<int> visitedValves)
    {
        for (; _routeIndex < _route.Count; _routeIndex++)
        {
            var distance = _graph[_location.Order][_route[_routeIndex]];
            if (distance > 0)
            {
                var valve = _pipeSystem[_indexToName[_route[_routeIndex]]];
                if (! valve.IsOpen && valve.FlowRate > 0 && !visitedValves.Contains(valve.Order))
                {
                    visitedValves.Add(valve.Order);
                    _target = valve;
                    return distance;
                }
            }
        }

        return 0;
    }
}
