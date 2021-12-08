using System;
using Xunit;
using Day8.Logic;
using static Day8.UnitTests.Constants;
using System.Collections.Generic;

namespace Day8.UnitTests
{
    public class SubmarineDisplaysMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInvalidWiringIsUsed(string invalidWiring)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SubmarineDisplays(invalidWiring));
            Assert.Equal("Invalid wiring", exception.Message);
        }

        [Theory]
        [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 1)]
        [InlineData(@"be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe
edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", 2)]
        public void ParseInformationCorrectly(string wiring, int expectedSets)
        {
            var sut = new SubmarineDisplays(wiring);
            Assert.Equal(expectedSets, sut.TotalScannings);
        }

        [Fact]
        public void CountDigitsWithUniqueNumberOfSegments()
        {
            var sut = new SubmarineDisplays(SAMPLE_SCANNINGS);
            Assert.Equal(26, sut.DigitsWithUniqueNumberOfSegments);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new SubmarineDisplays(REAL_SCANNINGS);
            Assert.Equal(504, sut.DigitsWithUniqueNumberOfSegments);
        }

        [Fact]
        public void OrderWiring()
        {
            var sut = new SubmarineDisplays("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf");
            Assert.Collection(sut.GetDisplayFor(0),
                p1 => Assert.Equal("bcdef", p1),
                p2 => Assert.Equal("abcdf", p2),
                p3 => Assert.Equal("bcdef", p3),
                p4 => Assert.Equal("abcdf", p4));
        }

        [Theory]
        [MemberData(nameof(DecodingDisplaySamples))]
        public void DecodeDisplaySegmentsCorrectly(string data, char wireA, char wireB, char wireC, char wireD, char wireE, char wireF, char wireG)
        {
            var sut = new SubmarineDisplays(data);
            Assert.Collection(sut.GetWiringForDisplay(0),
                p1 => Assert.Equal(wireA, p1),
                p2 => Assert.Equal(wireB, p2),
                p3 => Assert.Equal(wireC, p3),
                p4 => Assert.Equal(wireD, p4),
                p5 => Assert.Equal(wireE, p5),
                p6 => Assert.Equal(wireF, p6),
                p7 => Assert.Equal(wireG, p7));
        }

        public static IEnumerable<object[]> DecodingDisplaySamples()
        {
            yield return new object[] { "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 'd', 'e', 'a', 'f', 'g', 'b', 'c' };
            yield return new object[] { "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", 'd', 'g', 'b', 'c', 'a', 'e', 'f' };
        }

        [Theory]
        [InlineData("acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf", 5353)]
        [InlineData("be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe", 8394)]
        [InlineData("edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc", 9781)]
        [InlineData("fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg", 1197)]
        [InlineData("fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb", 9361)]
        [InlineData("aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea", 4873)]
        [InlineData("fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb", 8418)]
        [InlineData("dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe", 4548)]
        [InlineData("bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef", 1625)]
        [InlineData("egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb", 8717)]
        [InlineData("gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce", 4315)]
        public void ReturnFixedDisplay(string data, int expectedDisplay)
        {
            var sut = new SubmarineDisplays(data);
            Assert.Equal(expectedDisplay, sut.GetFixedDisplayFor(0));
        }

        [Fact]
        public void ReturnSumOfDisplays_WhenUsingSampleScannings()
        {
            var sut = new SubmarineDisplays(SAMPLE_SCANNINGS);
            Assert.Equal(61229, sut.GetSumOfDisplays());
        }

        [Fact]
        public void SolveSecondPuzzle()
        {
            var sut = new SubmarineDisplays(REAL_SCANNINGS);
            Assert.Equal(1073431, sut.GetSumOfDisplays());
        }
    }
}