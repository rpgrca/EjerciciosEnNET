using Day16.Logic;
using static Day16.UnitTests.Constants;

namespace Day16.UnitTests;

public class GraphParserMust
{
    [Fact]
    public void Test1()
    {
        const string input = "Valve BB has flow rate=0; tunnels lead to valves AA\nValve AA has flow rate=0; tunnels lead to valves BB";
        var sut = new GraphParser(input);
        Assert.Collection(sut.Graph,
            g1 => Assert.Equal(new[] { 0, 1 }, g1),
            g2 => Assert.Equal(new[] { 1, 0 }, g2));
    }

    [Fact]
    public void Test2()
    {
        const string input = @"Valve AA has flow rate=0; tunnels lead to valves DD, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=22; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA";

        var sut = new GraphParser(input);
        Assert.Collection(sut.Graph,
            g1 => Assert.Equal(new[] { 0, 1, 2, 1 }, g1),
            g2 => Assert.Equal(new[] { 1, 0, 1, 2 }, g2),
            g3 => Assert.Equal(new[] { 2, 1, 0, 1 }, g3),
            g4 => Assert.Equal(new[] { 1, 2, 1, 0 }, g4));
    }

    [Fact]
    public void Test3()
    {
        var sut = new GraphParser(SAMPLE_INPUT);
        Assert.Collection(sut.Graph,
            g1 => Assert.Equal(new[] { 0, 1, 2, 1, 2, 3, 4, 5, 1, 2 }, g1),
            g2 => Assert.Equal(new[] { 1, 0, 1, 2, 3, 4, 5, 6, 2, 3 }, g2),
            g3 => Assert.Equal(new[] { 2, 1, 0, 1, 2, 3, 4, 5, 3, 4 }, g3),
            g4 => Assert.Equal(new[] { 1, 2, 1, 0, 1, 2, 3, 4, 2, 3 }, g4),
            g5 => Assert.Equal(new[] { 2, 3, 2, 1, 0, 1, 2, 3, 3, 4 }, g5),
            g6 => Assert.Equal(new[] { 3, 4, 3, 2, 1, 0, 1, 2, 4, 5 }, g6),
            g7 => Assert.Equal(new[] { 4, 5, 4, 3, 2, 1, 0, 1, 5, 6 }, g7),
            g8 => Assert.Equal(new[] { 5, 6, 5, 4, 3, 2, 1, 0, 6, 7 }, g8),
            g9 => Assert.Equal(new[] { 1, 2, 3, 2, 3, 4, 5, 6, 0, 1 }, g9),
            ga => Assert.Equal(new[] { 2, 3, 4, 3, 4, 5, 6, 7, 1, 0 }, ga));
    }
}
