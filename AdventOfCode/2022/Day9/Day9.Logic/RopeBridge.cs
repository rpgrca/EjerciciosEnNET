using Day9.Logic.Directions;

namespace Day9.Logic;

public class RopeBridge
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<Knot> _knots;
    private readonly Dictionary<(int X, int Y), int> _uniquePositions;

    public int VisitedPositions => _uniquePositions.Count;

    public RopeBridge(string input, int knots = 2)
    {
        _input = input;
        _knots = new List<Knot>();
        _uniquePositions = new Dictionary<(int X, int Y), int> { { (0, 0), 1 } };
        _lines = _input.Split("\n");

        while (knots-- > 0)
        {
            _knots.Add(new Knot());
        }

        Run();
    }

    private void Run()
    {
        foreach (var line in _lines)
        {
            var splittedLine = line.Split(" ");
            var steps = int.Parse(splittedLine[1]);
            var direction = DirectionFactory.Create(splittedLine[0], _knots, _uniquePositions);

            while (steps-- > 0)
            {
                direction.Move();
            }
        }
    }
}