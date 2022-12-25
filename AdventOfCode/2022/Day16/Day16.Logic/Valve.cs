namespace Day16.Logic;

public record Valve
{
    private readonly List<Valve> _connectedValves;
    private int _from;

    public int FlowRate { get; private set; }
    public bool IsOpen { get; private set; }
    public bool HasBeenVisited { get; private set; }
    public int Order { get; }
    public string Name { get; private set; }
    public List<Valve> ConnectedValves => _connectedValves;

    public Valve(int order, string name, int flowRate)
    {
        Order = order;
        Name = name;
        FlowRate = flowRate;
        IsOpen = false;
        _from = -1;
        _connectedValves = new List<Valve>();
    }

    public void AddConnectedValve(Valve valve)
    {
        var index = 0;
        for (; index < _connectedValves.Count; index++)
        {
            if (valve.FlowRate > _connectedValves[index].FlowRate)
            {
                break;
            }
        }

        _connectedValves.Insert(index, valve);
    }

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

    public void Visit() => HasBeenVisited = true;

    public void Unvisit() => HasBeenVisited = false;

    public int GetReleasedPressure(int maximumTime) => _from > -1? (maximumTime - _from - 1) * FlowRate : 0;
}
