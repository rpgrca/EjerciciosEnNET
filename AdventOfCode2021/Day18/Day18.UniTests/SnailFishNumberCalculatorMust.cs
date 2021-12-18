using System;
using System.Collections.Generic;
using Xunit;
using Day18.Logic;
using static Day18.UniTests.Constants;

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

            var sut = new SnailFishNumberExploder(value).Apply();
            Assert.Equal(expectedNumber, sut);
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

            var sut = new SnailFishNumberSplitter(value).Apply();
            Assert.Equal(expectedNumber, sut);
        }

        public static IEnumerable<object[]> SplitterSampleFeeder()
        {
            yield return new object[] { "[[[[0,7],4],[15,[0,13]]],[1,1]]", ((((0,7).AsNumber(),4).AsNumber(),((7,8).AsNumber(),(0,13).AsNumber()).AsNumber()).AsNumber(),(1,1).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", ((((0,7).AsNumber(),4).AsNumber(),((7,8).AsNumber(),(0,(6,7).AsNumber()).AsNumber()).AsNumber()).AsNumber(),(1,1).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[0,7],[7,7]],[[8,8],[6,7]]],[[[7,6],38],[8,[9,0]]]]", ((((0,7).AsNumber(),(7,7).AsNumber()).AsNumber(),((8,8).AsNumber(),(6,7).AsNumber()).AsNumber()).AsNumber(),(((7,6).AsNumber(),(19,19).AsNumber()).AsNumber(),(8,(9,0).AsNumber()).AsNumber()).AsNumber()).AsNumber() };
        }

        [Theory]
        [MemberData(nameof(SumFeeder))]
        public void SimplifySnailFishNumberCorrectly(string homework, SnailFishNumber expectedResult)
        {
            var sut = new SnailFishNumberCalculator(homework);
            sut.AddNumbers();
            Assert.Equal(expectedResult, sut.Result);
        }

        public static IEnumerable<object[]> SumFeeder()
        {
            yield return new object[] { "[[[[4,3],4],4],[7,[[8,4],9]]]\n[1,1]", ((((0,7).AsNumber(),4).AsNumber(),((7,8).AsNumber(),(6,0).AsNumber()).AsNumber()).AsNumber(),(8,1).AsNumber()).AsNumber() };
            yield return new object[] { "[1,1]\n[2,2]\n[3,3]\n[4,4]", ((((1,1).AsNumber(),(2,2).AsNumber()).AsNumber(),(3,3).AsNumber()).AsNumber(),(4,4).AsNumber()).AsNumber() };
            yield return new object[] { "[1,1]\n[2,2]\n[3,3]\n[4,4]\n[5,5]", ((((3,0).AsNumber(),(5,3).AsNumber()).AsNumber(),(4,4).AsNumber()).AsNumber(),(5,5).AsNumber()).AsNumber() };
            yield return new object[] { "[[[[1,1],[2,2]],[3,3]],[4,4]]\n[5,5]", ((((3,0).AsNumber(),(5,3).AsNumber()).AsNumber(),(4,4).AsNumber()).AsNumber(),(5,5).AsNumber()).AsNumber() };
            yield return new object[] { "[1,1]\n[2,2]\n[3,3]\n[4,4]\n[5,5]\n[6,6]", ((((5,0).AsNumber(),(7,4).AsNumber()).AsNumber(),(5,5).AsNumber()).AsNumber(),(6,6).AsNumber()).AsNumber() };
        }

        [Theory]
        [InlineData("[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]\n[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]", "[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]")]
        [InlineData("[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]\n[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]", "[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]")]
        [InlineData("[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]\n[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]", "[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]")]
        [InlineData("[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]\n[7,[5,[[3,8],[1,4]]]]", "[[[[7,7],[7,8]],[[9,5],[8,7]]],[[[6,8],[0,8]],[[9,9],[9,0]]]]")]
        [InlineData("[[[[7,7],[7,8]],[[9,5],[8,7]]],[[[6,8],[0,8]],[[9,9],[9,0]]]]\n[[2,[2,2]],[8,[8,1]]]", "[[[[6,6],[6,6]],[[6,0],[6,7]]],[[[7,7],[8,9]],[8,[8,1]]]]")]
        [InlineData("[[[[6,6],[6,6]],[[6,0],[6,7]]],[[[7,7],[8,9]],[8,[8,1]]]]\n[2,9]", "[[[[6,6],[7,7]],[[0,7],[7,7]]],[[[5,5],[5,6]],9]]")]
        [InlineData("[[[[6,6],[7,7]],[[0,7],[7,7]]],[[[5,5],[5,6]],9]]\n[1,[[[9,3],9],[[9,0],[0,7]]]]", "[[[[7,8],[6,7]],[[6,8],[0,8]]],[[[7,7],[5,0]],[[5,5],[5,6]]]]")]
        [InlineData("[[[[7,8],[6,7]],[[6,8],[0,8]]],[[[7,7],[5,0]],[[5,5],[5,6]]]]\n[[[5,[7,4]],7],1]", "[[[[7,7],[7,7]],[[8,7],[8,7]]],[[[7,0],[7,7]],9]]")]
        [InlineData("[[[[7,7],[7,7]],[[8,7],[8,7]]],[[[7,0],[7,7]],9]]\n[[[[4,2],2],6],[8,7]]", "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
        public void SolveSampleHomework_WhenDoingItStepByStep(string homework, string expectedResult)
        {
            var sut = new SnailFishNumberCalculator(homework);
            sut.AddNumbers();
            Assert.Equal(expectedResult, sut.Result.ToString());
        }

        [Fact]
        public void SolveFirstSampleHomework()
        {
            var sut = new SnailFishNumberCalculator(SAMPLE_HOMEWORK);
            sut.AddNumbers();
            Assert.Equal(((((8,7).AsNumber(),(7,7).AsNumber()).AsNumber(),((8,6).AsNumber(),(7,7).AsNumber()).AsNumber()).AsNumber(),(((0,7).AsNumber(),(6,6).AsNumber()).AsNumber(),(8,7).AsNumber()).AsNumber()).AsNumber(), sut.Result);
        }

        [Fact]
        public void SolveSecondSampleHomework()
        {
            var sut = new SnailFishNumberCalculator(SECOND_SAMPLE_HOMEWORK);
            sut.AddNumbers();
            Assert.Equal(((((6,6).AsNumber(),(7,6).AsNumber()).AsNumber(),((7,7).AsNumber(),(7,0).AsNumber()).AsNumber()).AsNumber(),(((7,7).AsNumber(),(7,7).AsNumber()).AsNumber(),((7,8).AsNumber(),(9,9).AsNumber()).AsNumber()).AsNumber()).AsNumber(), sut.Result);
        }

        [Theory]
        [InlineData("[9,1]", 29)]
        [InlineData("[1,9]", 21)]
        [InlineData("[[9,1],[1,9]]", 129)]
        [InlineData("[[1,2],[[3,4],5]]", 143)]
        [InlineData("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
        [InlineData("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
        [InlineData("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
        [InlineData("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
        [InlineData("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
        public void CalculateResultMagnitudeCorrectly(string number, int expectedMagnitude)
        {
            var parser = new SnailFishNumberParser(number);
            var sut = parser.Value;
            Assert.Equal(expectedMagnitude, sut.GetMagnitude());
        }

        [Fact]
        public void SolveMagnitudeForSecondSampleHomework()
        {
            var sut = new SnailFishNumberCalculator(SECOND_SAMPLE_HOMEWORK);
            sut.AddNumbers();
            Assert.Equal(4140, sut.Result.GetMagnitude());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new SnailFishNumberCalculator(REAL_HOMEWORK);
            sut.AddNumbers();
            Assert.Equal(3411, sut.Result.GetMagnitude());

        }
    }
}
