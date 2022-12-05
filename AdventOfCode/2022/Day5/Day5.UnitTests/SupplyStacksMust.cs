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

    [Fact]
    public void LoadPuzzleInputCorrectly()
    {
        var sut = new SupplyStacks(PUZZLE_INPUT, 9);
        Assert.Collection(sut.Stacks,
            p1 => {
                Assert.Equal('G', p1[0]);
                Assert.Equal('B', p1[1]);
                Assert.Equal('D', p1[2]);
                Assert.Equal('C', p1[3]);
                Assert.Equal('P', p1[4]);
                Assert.Equal('R', p1[5]);
            },
            p2 => {
                Assert.Equal('G', p2[0]);
                Assert.Equal('V', p2[1]);
                Assert.Equal('H', p2[2]);
            },
            p3 => {
                Assert.Equal('M', p3[0]);
                Assert.Equal('P', p3[1]);
                Assert.Equal('J', p3[2]);
                Assert.Equal('D', p3[3]);
                Assert.Equal('Q', p3[4]);
                Assert.Equal('S', p3[5]);
                Assert.Equal('N', p3[6]);
            },
            p4 => {
                Assert.Equal('M', p4[0]);
                Assert.Equal('N', p4[1]);
                Assert.Equal('C', p4[2]);
                Assert.Equal('D', p4[3]);
                Assert.Equal('G', p4[4]);
                Assert.Equal('L', p4[5]);
                Assert.Equal('S', p4[6]);
                Assert.Equal('P', p4[7]);
            },
            p5 => {
                Assert.Equal('S', p5[0]);
                Assert.Equal('L', p5[1]);
                Assert.Equal('F', p5[2]);
                Assert.Equal('P', p5[3]);
                Assert.Equal('C', p5[4]);
                Assert.Equal('N', p5[5]);
                Assert.Equal('B', p5[6]);
                Assert.Equal('J', p5[7]);
            },
            p6 => {
                Assert.Equal('S', p6[0]);
                Assert.Equal('T', p6[1]);
                Assert.Equal('G', p6[2]);
                Assert.Equal('V', p6[3]);
                Assert.Equal('Z', p6[4]);
                Assert.Equal('D', p6[5]);
                Assert.Equal('B', p6[6]);
                Assert.Equal('Q', p6[7]);
            },
            p7 => {
                Assert.Equal('Q', p7[0]);
                Assert.Equal('T', p7[1]);
                Assert.Equal('F', p7[2]);
                Assert.Equal('H', p7[3]);
                Assert.Equal('M', p7[4]);
                Assert.Equal('Z', p7[5]);
                Assert.Equal('B', p7[6]);
            },
            p8 => {
                Assert.Equal('F', p8[0]);
                Assert.Equal('B', p8[1]);
                Assert.Equal('D', p8[2]);
                Assert.Equal('M', p8[3]);
                Assert.Equal('C', p8[4]);
            },
            p9 => {
                Assert.Equal('G', p9[0]);
                Assert.Equal('Q', p9[1]);
                Assert.Equal('C', p9[2]);
                Assert.Equal('F', p9[3]);
            });
    }
}