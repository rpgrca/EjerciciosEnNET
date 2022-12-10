namespace Day10.Logic;

public class CathodeRayTube
{
    private readonly string _input;
    private readonly int[] _samples;
    private readonly string[] _lines;
    private readonly int _cycle;
    private char[] _sprite;

    public int X { get; private set; }
    public int SignalStrength { get; private set; }
    public string Output { get; private set; }

    public CathodeRayTube(string input, int[] samples)
    {
        _input = input;
        _samples = samples;
        _lines = input.Split("\n");
        _cycle = 1;
        _sprite = new char[40];
        Output = string.Empty;
        X = 1;

        RelocateSprite();
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

                    DrawPixel();
                    _cycle += 1;
                    break;

                case "addx":
                    if (_samples.Contains(_cycle))
                    {
                        SignalStrength += _cycle * X;
                    }

                    DrawPixel();
                    _cycle += 1;

                    if (_samples.Contains(_cycle))
                    {
                        SignalStrength += _cycle * X;
                    }

                    DrawPixel();
                    _cycle += 1;

                    X += int.Parse(instruction[1]);
                    RelocateSprite();
                    break;
            }
        }
    }

    private void RelocateSprite()
    {
        for (var index = 0; index < _sprite.Length; index++)
        {
            _sprite[index] = index >= X - 1 && index <= X + 1 ? '#' : '.';
        }
    }

    private void DrawPixel()
    {
        Output += _sprite[(_cycle - 1) % 40];
        if (_cycle % 40 == 0)
        {
            Output += "\n";
        }
    }
}