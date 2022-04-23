namespace ColorGhost.Logic;

public class Ghost
{
    private static readonly string[] Color = { "white", "yellow", "purple", "red" };
    private readonly string _color;

    public Ghost() => _color = Color[new Random().Next() % Color.Length];

    public string GetColor() => _color;
}