namespace Day19.Logic;

public class Robot
{
    private readonly (int, int, int, int) _generation;

    public Robot((int, int, int, int) generation) => _generation = generation;

    public (int Geode, int Obsidian, int Clay, int Ore) Generate() => _generation;
}
