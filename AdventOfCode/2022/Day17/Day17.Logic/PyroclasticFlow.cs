namespace Day17.Logic;

public class PyroclasticFlow
{
    private string _input;
    private int _height;

    public string Image { get; private set; } = "|####...|\n+-------+";

    public PyroclasticFlow(string input, int height)
    {
        _input = input;
        _height = height;
    }

    public int Height => 1;

}
