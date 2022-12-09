namespace Day9.Logic.Directions;

internal class DirectionFactory
{
    public static IDirection Create(string direction, List<Knot> knots, Dictionary<(int X, int Y), int> uniquePositions) =>
        direction switch
        {
            "R" => new Right(knots, uniquePositions),
            "L" => new Left(knots, uniquePositions),
            "U" => new Up(knots, uniquePositions),
            _ => new Down(knots, uniquePositions)
        };
}
