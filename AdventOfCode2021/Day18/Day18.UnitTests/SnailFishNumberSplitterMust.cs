using System.Collections.Generic;
using Xunit;
using Day18.Logic;
using Day18.Logic.Numbers;

namespace Day18.UnitTests
{
    public partial class SnailFishNumberSplitterMust
    {
        [Theory]
        [MemberData(nameof(SplitterSampleFeeder))]
        public void ReduceSnailFishNumberCorrectly(string number, SnailFishNumber expectedNumber)
        {
            var parser = new SnailFishNumberParser(number);
            var value = parser.Value;

            var sut = new SnailFishNumberSplitter(value).Apply();
            Assert.Equal(expectedNumber, sut);
        }

        public static IEnumerable<object[]> SplitterSampleFeeder()
        {
            yield return new object[] { "[[[[0,7],4],[15,[0,13]]],[1,1]]", ((((0, 7).AsNumber(), 4).AsNumber(), ((7, 8).AsNumber(), (0, 13).AsNumber()).AsNumber()).AsNumber(), (1, 1).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", ((((0, 7).AsNumber(), 4).AsNumber(), ((7, 8).AsNumber(), (0, (6, 7).AsNumber()).AsNumber()).AsNumber()).AsNumber(), (1, 1).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[0,7],[7,7]],[[8,8],[6,7]]],[[[7,6],38],[8,[9,0]]]]", ((((0, 7).AsNumber(), (7, 7).AsNumber()).AsNumber(), ((8, 8).AsNumber(), (6, 7).AsNumber()).AsNumber()).AsNumber(), (((7, 6).AsNumber(), (19, 19).AsNumber()).AsNumber(), (8, (9, 0).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
        }
    }
}