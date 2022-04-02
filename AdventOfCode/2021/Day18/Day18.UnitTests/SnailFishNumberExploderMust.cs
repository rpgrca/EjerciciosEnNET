using System.Collections.Generic;
using Xunit;
using Day18.Logic;
using Day18.Logic.Numbers;
using Day18.Logic.Reducers;

namespace Day18.UnitTests
{
    public class SnailFishNumberExploderMust
    {
        [Theory]
        [MemberData(nameof(ExplodeSampleFeeder))]
        public void ExplodeSnailFishNumbersCorrectly(string number, SnailFishNumber expectedNumber)
        {
            var parser = new SnailFishNumberParser(number);
            var value = parser.Value;

            var sut = new SnailFishNumberExploder(value).Apply();
            Assert.Equal(expectedNumber, sut);
        }

        public static IEnumerable<object[]> ExplodeSampleFeeder()
        {
            yield return new object[] { "[[[[[9,8],1],2],3],4]", ((((0, 9).AsNumber(), 2).AsNumber(), 3).AsNumber(), 4).AsNumber() };
            yield return new object[] { "[7,[6,[5,[4,[3,2]]]]]", (7, (6, (5, (7, 0).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
            yield return new object[] { "[[6,[5,[4,[3,2]]]],1]", ((6, (5, (7, 0).AsNumber()).AsNumber()).AsNumber(), 3).AsNumber() };
            yield return new object[] { "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", ((3, (2, (8, 0).AsNumber()).AsNumber()).AsNumber(), (9, (5, (4, (3, 2).AsNumber()).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
            yield return new object[] { "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", ((3, (2, (8, 0).AsNumber()).AsNumber()).AsNumber(), (9, (5, (7, 0).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]", ((((0, 7).AsNumber(), 4).AsNumber(), (7, ((8, 4).AsNumber(), 9).AsNumber()).AsNumber()).AsNumber(), (1, 1).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[0,7],4],[7,[[8,4],9]]],[1,1]]", ((((0, 7).AsNumber(), 4).AsNumber(), (15, (0, 13).AsNumber()).AsNumber()).AsNumber(), (1, 1).AsNumber()).AsNumber() };
        }
    }
}