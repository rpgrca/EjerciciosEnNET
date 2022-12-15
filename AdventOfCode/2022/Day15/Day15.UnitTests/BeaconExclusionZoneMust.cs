using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests;

public class BeaconExclusionZoneMust
{
    [Theory]
    [MemberData(nameof(SingleLineFeeder))]
    public void ParseSingleLineInputCorrectly(string input, (int X, int Y) expectedSensor, (int X, int Y) expectedBeacon)
    {
        var sut = new BeaconExclusionZone(input);
        Assert.Collection(sut.Sensors, s1 => Assert.Equal(expectedSensor, s1));
        Assert.Collection(sut.Beacons, b1 => Assert.Equal(expectedBeacon, b1));
    }

    public static IEnumerable<object[]> SingleLineFeeder()
    {
        yield return new object[] { "Sensor at x=2, y=18: closest beacon is at x=-2, y=15", (2, 18), (-2, 15) };
    }

}