using Day16.Logic;
using static Day16.UnitTests.Constants;

namespace Day16.UnitTests;

public class PressureReleaseValveMust
{
    [Theory]
    [InlineData("Valve AA has flow rate=0; tunnels lead to valves BB\nValve BB has flow rate=0; tunnels lead to valves AA", 0, 0)]
    [InlineData("Valve AA has flow rate=0; tunnels lead to valves BB\nValve BB has flow rate=13; tunnels lead to valves AA", 13, 364)]
    public void Test1(string input, int expectedFlowRate, int expectedPressureRelease)
    {
        var sut = new PressureReleaseValve(input);
        Assert.Equal(expectedFlowRate, sut.FlowRate);
        Assert.Equal(expectedPressureRelease, sut.ReleasedPressure);
    }
}