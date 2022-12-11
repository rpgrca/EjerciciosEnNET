namespace Day10.Logic;

public class CathodeRayTube
{
    private readonly string[] _lines;
    private int _cycle;
    private int _x;

    public CathodeRayTube(string input)
    {
        _lines = input.Split("\n");
        _cycle = 1;
        _x = 1;
    }

    public void Execute(ICpu interrupt)
    {
        foreach (var line in _lines)
        {
            var instruction = line.Split(" ");

            switch (instruction[0])
            {
                case "noop":
                    Trigger(interrupt);
                    break;

                case "addx":
                    Trigger(interrupt);
                    Trigger(interrupt);

                    _x += int.Parse(instruction[1]);
                    break;
            }
        }
    }

    private void Trigger(ICpu interrupt)
    {
        interrupt.Trigger(_cycle, _x);
        _cycle += 1;
    }
}