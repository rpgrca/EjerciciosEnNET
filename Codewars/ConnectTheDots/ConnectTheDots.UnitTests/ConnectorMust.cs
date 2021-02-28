using System.Reflection;
using System;
using Xunit;
using ConnectTheDots.Logic;

namespace ConnectTheDots.UnitTests
{
    public class ConnectorMust
    {
        [Theory]
        [InlineData()]
        public void Test1()
        {
            var input = @" 
 a       b 
 e         
            
 d       c 
 
";

            var expectedValue = @"          
 *********
 *       *
 *       *
 *********
 ";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }
    }
}
