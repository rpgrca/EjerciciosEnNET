namespace Day10.Logic;

public class DrawingInterrupt : ICpu
{
    public string Output { get; private set; }

    public DrawingInterrupt() => Output = string.Empty;

    public void Trigger(int cycle, int x)
    {
        Output += Math.Abs((cycle - 1) % 40 - x) <= 1? "#" : ".";
        if (cycle % 40 == 0)
        {
            Output += "\n";
        }
    }
}