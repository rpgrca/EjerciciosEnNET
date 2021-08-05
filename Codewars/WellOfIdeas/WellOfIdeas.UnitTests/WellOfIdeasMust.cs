using System;
using Xunit;
using WellOfIdeas.Logic;

namespace WellOfIdeas.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("Fail!", Kata.Well(new string[] {"bad", "bad", "bad"}));
            Assert.Equal("Publish!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad"}));
            Assert.Equal("I smell a series!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad", "good", "bad", "bad", "good"}));
        }
    }
}
