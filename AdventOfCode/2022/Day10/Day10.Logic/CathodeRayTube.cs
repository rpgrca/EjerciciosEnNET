namespace Day10.Logic;

public class CathodeRayTube
{
    private readonly string _input;
    private readonly int[] _samples;
    private readonly string[] _lines;
    private readonly int _cycle;

    public int X { get; private set; }
    public int SignalStrength { get; private set; }

    public CathodeRayTube(string input, int[] samples)
    {
        _input = input;
        _samples = samples;
        _lines = input.Split("\n");
        _cycle = 1;
        X = 1;

        foreach (var line in _lines)
        {
            var instruction = line.Split(" ");
            switch (instruction[0])
            {
                case "noop":
                    if (_samples.Contains(_cycle))
                    {
                        SignalStrength += _cycle * X;
                    }

                    _cycle += 1;
                    break;

                case "addx":
                    if (_samples.Contains(_cycle))
                    {
                        SignalStrength += _cycle * X;
                    }

                    _cycle += 1;

                    if (_samples.Contains(_cycle))
                    {
                        SignalStrength += _cycle * X;
                    }

                    _cycle += 1;
                    X += int.Parse(instruction[1]);
                    break;
            }
        }
    }
}
