using Xunit;
using AdventOfCode2020.Day7.Logic;

namespace AdventOfCode2020.Day7.UnitTests
{
    public class BagMust
    {
        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.", "bright white")]
        [InlineData("light red bags contain 1 bright white bag, 2 muted yellow bags.", "light red")]
        public void GetDescriptionFromRule(string rule, string expectedDescription)
        {
            var sut = new Bag(rule);
            Assert.True(sut.IsOf(expectedDescription));
        }

        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.")]
        [InlineData("light red bags contain 1 bright white bag, 2 muted yellow bags.")]
        public void ReturnFalse_WhenAskingIfItsOfADifferentDescription(string rule)
        {
            var sut = new Bag(rule);
            Assert.False(sut.IsOf("dampened violet"));
        }

        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.")]
        [InlineData("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.")]
        public void ReturnTrue_WhenAskingIfItCanContainExpectedBag(string rule)
        {
            var sut = new Bag(rule);
            Assert.True(sut.CanContainBagOf("shiny gold"));
        }

        [Theory]
        [InlineData("bright white bags contain 1 shiny gold bag.")]
        [InlineData("muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.")]
        public void ReturnFalse_WhenAskingIfItCanContainUnexpectedBag(string rule)
        {
            var sut = new Bag(rule);
            Assert.False(sut.CanContainBagOf("dampened violet"));
        }

        [Fact]
        public void ReturnFalse_WhenAskingIfItCanContainItself()
        {
            var sut = new Bag("bright white bags contain 1 shiny gold bag.");
            Assert.False(sut.CanContainBagOf("bright white"));
        }
    }
}
