using Day5.Logic;
using static Day5.UnitTests.Constants;

namespace Day5.UnitTests;

public class SupplyStacksMust
{
    [Fact]
    public void LoadSampleInputCorrectly()
    {
        var sut = new SupplyStacks(SAMPLE_INPUT, 3);
        Assert.Collection(sut.Stacks,
            p1 => {
                Assert.Equal('N', p1[0]);
                Assert.Equal('Z', p1[1]);
            },
            p2 => {
                Assert.Equal('D', p2[0]);
                Assert.Equal('C', p2[1]);
                Assert.Equal('M', p2[2]);
            },
            p3 => {
                Assert.Equal('P', p3[0]);
            });
    }
}