using System;
using Xunit;
using Day10.Logic;

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
    }
}
