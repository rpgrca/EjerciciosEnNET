using System;
using Xunit;
using WellOfIdeas.Logic;

namespace WellOfIdeas.UnitTests
{
    public class WellOfIdeasMust
    {
        [Fact]
        public void ReturnFail_WhenThereAreNoGoodAndAtLeastTwoBads() =>
            Assert.Equal("Fail!", Kata.Well(new string[] {"bad", "bad", "bad"}));

        [Fact]
        public void ReturnPublish_WhenThereAreOneOrTwoGoods() =>
            Assert.Equal("Publish!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad"}));

        [Fact]
        public void ReturnISmellASeries_WhenThereAreMoreThanTwoGoods() =>
            Assert.Equal("I smell a series!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad", "good", "bad", "bad", "good"}));

        [Fact]
        public void ReturnFail_WhenThereIsNoInput() =>
            Assert.Equal("Fail!", Kata.Well(Array.Empty<string>()));

        [Fact]
        public void ReturnFail_WhenThereAreNoGoodIdeas() =>
            Assert.Equal("Fail!", Kata.Well(new string[] { "bad" }));
    }
}