namespace Day10.Logic;

public class CathodeRayTube
{
    private readonly string _input;
    private readonly string[] _lines;

    public int X { get; private set; }

    public CathodeRayTube(string input)
    {
        _input = input;
        _lines = input.Split("\n");
        X = 1;

        foreach (var line in _lines)
        {
            var instruction = line.Split(" ");
            switch (instruction[0])
            {
                case "noop":
                    break;

                case "addx":
                    X += int.Parse(instruction[1]);
                    break;
            }
        }
    }
}
