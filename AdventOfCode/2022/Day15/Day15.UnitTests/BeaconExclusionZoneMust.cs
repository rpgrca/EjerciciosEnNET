using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests;

public class BeaconExclusionZoneMust
{
    [Theory]
    [MemberData(nameof(SingleLineFeeder))]
    public void ParseSingleLineInputCorrectly(string input, (int X, int Y) expectedSensor, (int X, int Y) expectedBeacon, int expectedRange)
    {
        var sut = new BeaconExclusionZone(input);
        Assert.Collection(sut.Sensors,
            s1 =>
            {
                Assert.Equal(expectedSensor.X, s1.X);
                Assert.Equal(expectedSensor.Y, s1.Y);
                Assert.Equal(expectedRange, s1.Range);
            });
        Assert.Collection(sut.Beacons, b1 => Assert.Equal(expectedBeacon, b1));
    }

    public static IEnumerable<object[]> SingleLineFeeder()
    {
        yield return new object[] { "Sensor at x=2, y=18: closest beacon is at x=-2, y=15", (2, 18), (-2, 15), 7 };
        yield return new object[] { "Sensor at x=9, y=16: closest beacon is at x=10, y=16", (9, 16), (10, 16), 1 };
    }

    [Fact]
    public void ParseMultipleLineInputCorrectly()
    {
        var sut = new BeaconExclusionZone("Sensor at x=14, y=3: closest beacon is at x=15, y=3\nSensor at x=9, y=16: closest beacon is at x=10, y=16");
        Assert.Equal(2, sut.Sensors.Count);
        Assert.Collection(sut.Sensors,
            s1 => 
            {
                Assert.Equal(14, s1.X);
                Assert.Equal(3, s1.Y);
                Assert.Equal(1, s1.Range);
            },
            s2 =>
            {
                Assert.Equal(9, s2.X);
                Assert.Equal(16, s2.Y);
                Assert.Equal(1, s2.Range);
            });
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

    [Theory]
    [InlineData(1, 0)]
    [InlineData(16, 2)]
    public void CalculateCoveredPositionsCorrectly(int position, int expectedCoverage)
    {
        var sut = new BeaconExclusionZone("Sensor at x=9, y=16: closest beacon is at x=10, y=16");
        Assert.Equal(expectedCoverage, sut.CalculateCoveredPositionsFor(position));
    }

    [Fact]
    public void SolveFirstSample()
    {
        var sut = new BeaconExclusionZone(SAMPLE_INPUT);
        Assert.Equal(26, sut.CalculateCoveredPositionsFor(10));
    }

    [Fact]
    public void SolveFirstPuzzle()
    {
        var sut = new BeaconExclusionZone(PUZZLE_INPUT);
        Assert.Equal(4737567, sut.CalculateCoveredPositionsFor(2000000));
    }

    [Fact]
    public void SolveSecondSample()
    {
        var sut = new BeaconExclusionZone(SAMPLE_INPUT);
        Assert.Equal(56000011UL, sut.GetDistressBeaconTuningFrequency(20));
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new BeaconExclusionZone(PUZZLE_INPUT);
        var value = sut.GetDistressBeaconTuningFrequency(4000000);
        Assert.True(value > 320708895UL);
        Assert.Equal(13267474686239UL, value);
    }
}
