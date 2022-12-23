using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests;

public class MonkeyMap3dMust
{
    [Fact]
    public void SolveSecondSample()
    {
        var sut = new MonkeyMap3d(SAMPLE_INPUT, SAMPLE_PLANES, SAMPLE_TRANSITON, SAMPLE_ORIGINS, 4, 0);
        sut.Run();
        Assert.Equal(5031, sut.FinalPassword);
    }

/*
0 → 1, (0 → 2), 0 → 3, (0 → 5)
1 → 0, 1 → 2, (1 → 4) (b), 1 → 5
(2 → 0), (2 → 1), (2 → 3), 2 → 4
(3 → 0) (b), 3 → 2, (3 → 4), 3 → 5
4 → 1, (4 → 2) (b), 4 → 3, (4 → 5)
5 → 0, (5 → 1) (b), (5 → 3), 5 → 4 (b)
*/

    [Fact]
    public void TransverseFromPlane0ToPlane5Correctly()
    {
        var sut = new MonkeyMap3d(SHORT_PUZZLE_INPUT, PUZZLE_PLANES, PUZZLE_TRANSITON, PUZZLE_ORIGINS, 50, 0);
        sut.Run();
        Assert.Equal(50 * 1000 + 104 * 4 + 3, sut.FinalPassword);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new MonkeyMap3d(PUZZLE_INPUT, PUZZLE_PLANES, PUZZLE_TRANSITON, PUZZLE_ORIGINS, 50, 0);
        sut.Run();
        Assert.True(10411 < sut.FinalPassword);
        Assert.True(146399 < sut.FinalPassword);
        Assert.Equal(195032, sut.FinalPassword);
    }
}