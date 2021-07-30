using System.Collections.Generic;
using Xunit;
using BreakCamelCase.Logic;

namespace BreakCamelCase.UnitTests
{
    public class BreakCamelCaseMust
    {
        public static IEnumerable<object[]> CommonTestCasesFeeder
        {
            get
            {
                yield return new object[] { "camelCasing", "camel Casing" };
                yield return new object[] { "camelCasingTest", "camel Casing Test" };
            }
        }

        [Theory]
        [MemberData(nameof(CommonTestCasesFeeder))]
        public void SplitCorrectlyWords_WhenCommonPhrasesAreUsed(string source, string expectedResult) =>
            Assert.Equal(expectedResult, Kata.BreakCamelCase(source));

        [Fact]
        public void ReturnEmptyString_WhenSourceTextIsEmpty() =>
            Assert.Equal(string.Empty, Kata.BreakCamelCase(string.Empty));

        [Fact]
        public void ReturnOneLetterWords_WhenUppercaseLettersAreConsecutive() =>
            Assert.Equal("A B C", Kata.BreakCamelCase("ABC"));
    }
}
