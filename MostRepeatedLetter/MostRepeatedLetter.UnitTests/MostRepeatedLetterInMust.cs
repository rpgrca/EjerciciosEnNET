using Xunit;

namespace MostRepeatedLetter.UnitTests
{
    public class MostRepeatedLetterMust
    {
        [Theory]
        [InlineData("a", "a")]
        [InlineData("bbbbbbaa", "b")]
        [InlineData("abccd", "c")]
        public void ReturnCorrectLetter(string text, string letter) =>
            Assert.Equal(letter, Logic.MostRepeatedLetter.In(text).Is);
    }
}