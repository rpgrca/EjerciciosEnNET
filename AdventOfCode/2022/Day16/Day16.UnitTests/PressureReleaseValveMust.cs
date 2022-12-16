using Day16.Logic;
using static Day16.UnitTests.Constants;

namespace Day16.UnitTests;

public class PressureReleaseValveMust
{

    /*
     *  AA <--> BB
     *
     *      +---+---+
     *      | A | B |
     *  +---+---+---+
     *  | A | 0 | 1 |
     *  +---+---+---+
     *  | B | 1 | 0 |
     *  +---+---+---+
     */
    [Theory]
    [InlineData("Valve AA has flow rate=0; tunnels lead to valves BB\nValve BB has flow rate=0; tunnels lead to valves AA", 0)]
    [InlineData("Valve AA has flow rate=0; tunnels lead to valves BB\nValve BB has flow rate=13; tunnels lead to valves AA", 28 * 13)]
    public void LoadInputCorrectly(string input, int expectedPressureRelease)
    {
        var graphParser = new GraphParser(input);
        var sut = new PressureReleaseValve(input, graphParser.Graph, graphParser.Names, graphParser.Flows);
        Assert.Equal(expectedPressureRelease, sut.ReleasedPressure);
    }

    /*
     *  AA <--> BB <--> CC
     *   ^               ^
     *   |               |
     *   V               |
     *  DD <-------------+
     *
     *      +---+---+---+---+
     *      | A | B | C | D |
     *  +---+---+---+---+---+
     *  | A | 0 | 1 | 2 | 1 |
     *  +---+---+---+---+---+
     *  | B | 1 | 0 | 1 | 2 |
     *  +---+---+---+---+---+
     *  | C | 2 | 1 | 0 | 1 |
     *  +---+---+---+---+---+
     *  | D | 1 | 2 | 1 | 0 |
     *  +---+---+---+---+---+
     */
    [Fact]
    public void CalculateBestPathCorrectly_WhenNoSkipsAreNecessary()
    {
        const string input = @"Valve AA has flow rate=0; tunnels lead to valves DD, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=22; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA";

        /*
         * == Minute 1 ==
         * No valves are open.
         * You move to valve DD
         *
         * == Minute 2 ==
         * No valves are open.
         * You open valve DD
         *
         * == Minute 3 ==
         * Valve DD is open, releasing 20 pressure
         * You move to valve CC
         *
         * == Minute 4 ==
         * Valve DD is open, releasing 20 pressure
         * You open valve CC
         *
         * == Minute 5 ==
         * Valves CC and DD are open, releasing 42 pressure
         * You move to valve BB
         *
         * == Minute 6 ==
         * Valves CC and DD are open, releasing 42 pressure
         * You open valve BB
         *
        * == Minute 7..30 ==
         * Valves BB, CC and DD are open, releasing 55 pressure
         *
         * Total: 24 * 55 + 2 * 42 + 2 * 20 = 1444
         */
        var graphParser = new GraphParser(input);
        var sut = new PressureReleaseValve(input, graphParser.Graph, graphParser.Names, graphParser.Flows);
        Assert.Equal(1444, sut.ReleasedPressure);
    }

    /*
     *  AA <--> BB <--> CC
     *   ^               ^
     *   |               |
     *   V               |
     *  DD <-------------+
     *
     *      +---+---+---+---+
     *      | A | B | C | D |
     *  +---+---+---+---+---+
     *  | A | 0 | 1 | 2 | 1 |
     *  +---+---+---+---+---+
     *  | B | 1 | 0 | 1 | 2 |
     *  +---+---+---+---+---+
     *  | C | 2 | 1 | 0 | 1 |
     *  +---+---+---+---+---+
     *  | D | 1 | 2 | 1 | 0 |
     *  +---+---+---+---+---+
     */
    [Fact]
    public void CalculateBestPathCorrectly_WhenSkipsAreNecessary()
    {
        const string input = @"Valve AA has flow rate=0; tunnels lead to valves DD, BB
Valve BB has flow rate=13; tunnels lead to valves CC, AA
Valve CC has flow rate=2; tunnels lead to valves DD, BB
Valve DD has flow rate=20; tunnels lead to valves CC, AA";

        /*
         * == Minute 1 ==
         * No valves are open.
         * You move to valve DD
         *
         * == Minute 2 ==
         * No valves are open.
         * You open valve DD
         *
         * == Minute 3 ==
         * Valve DD is open, releasing 20 pressure
         * You move to valve CC
         *
         * == Minute 4 ==
         * Valve DD is open, releasing 20 pressure
         * You move to valve BB
         *
         * == Minute 5 ==
         * Valve DD is open, releasing 20 pressure
         * You open valve BB
         *
         * == Minute 6 ==
         * Valve DD and BB are open, releasing 33 pressure
         * You move to valve CC
         *
         * == Minute 7 ==
         * Valve DD and BB are open, releasing 33 pressure
         * You open valve CC
         *
         * == Minute 8..30 ==
         * Valve BB, CC and DD are open, releasing 35 presure
         *
         * Total: 23 * 35 + 33 * 2 + 20 * 3 = 931
         */
        var graphParser = new GraphParser(input);
        var sut = new PressureReleaseValve(input, graphParser.Graph, graphParser.Names, graphParser.Flows);
        Assert.Equal(931, sut.ReleasedPressure);
    }

    [Fact]
    public void SolveFirstSample_WhenUsingGraphParser()
    {
        var graphParser = new GraphParser(SAMPLE_INPUT);
        var sut = new PressureReleaseValve(SAMPLE_INPUT, graphParser.Graph, graphParser.Names, graphParser.Flows);
        Assert.Equal(1651, sut.ReleasedPressure);
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var graphParser = new GraphParser(PUZZLE_INPUT);
        var sut = new PressureReleaseValve(PUZZLE_INPUT, graphParser.Graph, graphParser.Names, graphParser.Flows);
        Assert.Equal(1716, sut.ReleasedPressure);
    }
}