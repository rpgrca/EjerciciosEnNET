using System.ComponentModel;
using System;
using System.Collections.Generic;
using Xunit;
using Day18.Logic;

namespace Day18.UniTests
{
    public class SnailFishNumberCalculatorMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidHomework(string invalidHomework)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SnailFishNumberCalculator(invalidHomework));
            Assert.Equal("Invalid homework", exception.Message);
        }

        [Theory]
        [MemberData(nameof(SimpleExpressionFeeder))]
        public void BeInitializedCorrectly(string homework, SnailFishNumber expectedNumber)
        {
            var sut = new SnailFishNumberCalculator(homework);
            Assert.Collection(sut.Numbers,
                p1 => Assert.Equal(expectedNumber, p1));
        }

        public static IEnumerable<object[]> SimpleExpressionFeeder()
        {
            yield return new object[] { "[1,2]", (1, 2).AsNumber() };
            yield return new object[] { "[[1,2],3]", ((1, 2).AsNumber(), 3).AsNumber() };
            yield return new object[] { "[9,[8,7]]", (9, (8, 7).AsNumber()).AsNumber() };
            yield return new object[] { "[[1,9],[8,5]]", ((1, 9).AsNumber(), (8, 5).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[1,2],[3,4]],[[5,6],[7,8]]],9]", ((((1, 2).AsNumber(), (3, 4).AsNumber()).AsNumber(), ((5, 6).AsNumber(), (7, 8).AsNumber()).AsNumber()).AsNumber(), 9).AsNumber() };
            yield return new object[] { "[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]", (((9,(3,8).AsNumber()).AsNumber(),((0,9).AsNumber(),6).AsNumber()).AsNumber(),(((3,7).AsNumber(),(4,9).AsNumber()).AsNumber(),3).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]", ((((1,3).AsNumber(),(5,3).AsNumber()).AsNumber(),((1,3).AsNumber(),(8,7).AsNumber()).AsNumber()).AsNumber(),(((4,9).AsNumber(),(6,9).AsNumber()).AsNumber(),((8,2).AsNumber(),(7,3).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
        }

        [Fact]
        public void HaveResultEqualToInput_WhenNoOperationIsDone()
        {
            var sut = new SnailFishNumberCalculator("[1,2]");
            Assert.Equal((1, 2).AsNumber(), sut.Result);
        }

        [Fact]
        public void AddSnailFishNumbersCorrectly()
        {
            var sut = new SnailFishNumberCalculator("[1,2]\n[[3,4],5]");
            sut.AddNumbers();
            Assert.Equal(((1,2).AsNumber(), ((3,4).AsNumber(),5).AsNumber()).AsNumber(), sut.Result);
        }

        [Theory]
        [MemberData(nameof(ExplodeSampleFeeder))]
        public void ExplodeSnailFishNumbersCorrectly(string number, SnailFishNumber expectedNumber)
        {
            var parser = new SnailFishNumberParser(number);
            var value = parser.Value;

            var sut = new SnailFishNumberExploder(value);
            Assert.Equal(expectedNumber, sut.Value);
        }

        public static IEnumerable<object[]> ExplodeSampleFeeder()
        {
            yield return new object[] { "[[[[[9,8],1],2],3],4]", ((((0,9).AsNumber(),2).AsNumber(),3).AsNumber(),4).AsNumber() };
            yield return new object[] { "[7,[6,[5,[4,[3,2]]]]]", (7,(6,(5,(7,0).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
            yield return new object[] { "[[6,[5,[4,[3,2]]]],1]", ((6,(5,(7,0).AsNumber()).AsNumber()).AsNumber(),3).AsNumber() };
            yield return new object[] { "[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", ((3,(2,(8,0).AsNumber()).AsNumber()).AsNumber(),(9,(5,(4,(3,2).AsNumber()).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
            yield return new object[] { "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", ((3,(2,(8,0).AsNumber()).AsNumber()).AsNumber(),(9,(5,(7,0).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[[4,3],4],4],[7,[[8,4],9]]],[1,1]]", ((((0,7).AsNumber(),4).AsNumber(),(7,((8,4).AsNumber(),9).AsNumber()).AsNumber()).AsNumber(),(1,1).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[0,7],4],[7,[[8,4],9]]],[1,1]]", ((((0,7).AsNumber(),4).AsNumber(),(15,(0,13).AsNumber()).AsNumber()).AsNumber(),(1,1).AsNumber()).AsNumber() };
        }

        [Theory]
        [MemberData(nameof(SplitterSampleFeeder))]
        public void ReduceSnailFishNumberCorrectly(string number, SnailFishNumber expectedNumber)
        {
            var parser = new SnailFishNumberParser(number);
            var value = parser.Value;

            var sut = new SnailFishNumberSplitter(value);
            Assert.Equal(expectedNumber, sut.Value);
        }

        public static IEnumerable<object[]> SplitterSampleFeeder()
        {
            yield return new object[] { "[[[[0,7],4],[15,[0,13]]],[1,1]]", ((((0,7).AsNumber(),4).AsNumber(),((7,8).AsNumber(),(0,13).AsNumber()).AsNumber()).AsNumber(),(1,1).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", ((((0,7).AsNumber(),4).AsNumber(),((7,8).AsNumber(),(0,(6,7).AsNumber()).AsNumber()).AsNumber()).AsNumber(),(1,1).AsNumber()).AsNumber() };
        }
    }
}
