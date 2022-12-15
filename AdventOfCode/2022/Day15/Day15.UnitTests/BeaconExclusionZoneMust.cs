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
        yield return new object[] { "Sensor at x=9, y=16: closest beacon is at x=10, y=16", (9, 16), (10, 16) };
    }

    [Fact]
    public void ParseMultipleLineInputCorrectly()
    {
        var sut = new BeaconExclusionZone("Sensor at x=14, y=3: closest beacon is at x=15, y=3\nSensor at x=9, y=16: closest beacon is at x=10, y=16");
        Assert.Equal(2, sut.Sensors.Count);
        Assert.Single(sut.Sensors, (14, 3));
        Assert.Single(sut.Sensors, (9, 16));
        Assert.Equal(2, sut.Beacons.Count);
        Assert.Single(sut.Beacons, (10, 16));
        Assert.Single(sut.Beacons, (15, 3));
    }

    [Fact]
    public void LoadSampleCorrectly()
    {
        var sut = new BeaconExclusionZone(SAMPLE_INPUT);
        Assert.Equal(14, sut.Sensors.Count);
        Assert.Equal(6, sut.Beacons.Count);
    }

    [Fact]
    public void CalculateRangeCorrectly()
    {
        var sut = new BeaconExclusionZone(SAMPLE_INPUT);
        Assert.Equal((-2, 0), sut.TopLeft);
        Assert.Equal((25, 22), sut.BottomRight);
    }

    /*[Theory]
    [InlineData(1, 0)]
    [InlineData(16, 3)]
    public void CalculateCoveredPositionsCorrectly(int position, int expectedCoverage)
    {
        var sut = new BeaconExclusionZone("Sensor at x=9, y=16: closest beacon is at x=10, y=16");
        Assert.Equal(expectedCoverage, sut.CalculateCoveredPositionsFor(position));
    }*/
}
