namespace Day10.Logic;

public class SignalStrengthInterrupt : ICpu
{
    private readonly int[] _samples;

    public int SignalStrength { get; private set; }

    public SignalStrengthInterrupt(int[] samples) =>
        _samples = samples;

    public void Trigger(int cycle, int x)
    {
        if (_samples.Contains(cycle))
        {
            SignalStrength += cycle * x;
        }
    }
}