using System.Reflection;
using System;
using Xunit;
using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests
{
    public class SyntaxCheckerMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public void ThrowException_WhenInvalidCodeIsUsed(string invalidCode)
        {
            var exception = Assert.Throws<ArgumentException>(() => new SyntaxChecker(invalidCode));
            Assert.Equal("Invalid code", exception.Message);
        }

        [Theory]
        [InlineData("()")]
        [InlineData("[]")]
        [InlineData("([])")]
        [InlineData("{()()()}")]
        [InlineData("<([{}])>")]
        [InlineData("[<>({}){}[([])<>]]")]
        [InlineData("(((((((((())))))))))")]
        public void Test1(string input)
        {
            var sut = new SyntaxChecker(input);
            Assert.Empty(sut.GetSyntaxErrors());
        }

        [Theory]
        [InlineData("(]")]
        [InlineData("{()()()>")]
        [InlineData("(((()))}")]
        [InlineData("<([]){()}[{}])")]
        public void Test2(string input)
        {
            var sut = new SyntaxChecker(input);
            Assert.Collection(sut.GetSyntaxErrors(),
                p1 => Assert.Equal(input, p1));
        }

        [Fact]
        public void Test3()
        {
            var sut = new SyntaxChecker(SAMPLE_SUBSYSTEM);
            Assert.Collection(sut.GetSyntaxErrors(),
                p1 => Assert.Equal("{([(<{}[<>[]}>{[]{[(<()>", p1),
                p2 => Assert.Equal("[[<[([]))<([[{}[[()]]]", p2),
                p3 => Assert.Equal("[{[{({}]{}}([{[{{{}}([]", p3),
                p4 => Assert.Equal("[<(<(<(<{}))><([]([]()", p4),
                p5 => Assert.Equal("<{([([[(<>()){}]>(<<{{", p5));
        }

        [Fact]
        public void CalculateSyntaxErrorScoreCorrectly_WhenUsingSampleData()
        {
            var sut = new SyntaxChecker(SAMPLE_SUBSYSTEM);
            Assert.Equal(26397, sut.GetSyntaxErrorScore());
        }
    }
}
