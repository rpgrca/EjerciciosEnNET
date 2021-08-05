using System;
using Xunit;
using WellOfIdeas.Logic;

namespace WellOfIdeas.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void ReturnFail_WhenThereAreNoGoodAndAtLeastTwoBads()
        {
            Assert.Equal("Fail!", Kata.Well(new string[] {"bad", "bad", "bad"}));
        }

        [Fact]
        public void ReturnPublish_WhenThereAreOneOrTwoGoods()
        {
            Assert.Equal("Publish!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad"}));
        }

        [Fact]
        public void ReturnISmellASeries_WhenThereAreMoreThanTwoGoods()
        {
            Assert.Equal("I smell a series!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad", "good", "bad", "bad", "good"}));
        }
    }
}
