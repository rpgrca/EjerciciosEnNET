using System;
using Xunit;

namespace GravityFlip.UnitTests
{
    public class GravityFlipMust
    {
        [Fact]
        public void ReturnEmptyConfiguration_WhenFlipConfigurationIsNotRequired()
        {
            var sut = new Logic.GravityFlip();
            Assert.Equal(Array.Empty<int>(), sut.State);
        }
    }
}