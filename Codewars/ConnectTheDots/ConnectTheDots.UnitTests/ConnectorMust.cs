using Xunit;
using Codewars.ConnectTheDots.Logic;

namespace Codewars.ConnectTheDots.UnitTests
{
    public class ConnectorMust
    {
        [Fact]
        public void DrawHorizontalLineFromLeftToRight()
        {
            const string input = " a  b \n";
            const string expectedValue = " **** \n";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Fact]
        public void DrawHorizontalLineFromRightToLeft()
        {
            const string input = @"        
 b    a 
        
";
            const string expectedValue = @"        
 ****** 
        
";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Fact]
        public void DrawVerticalLineFromTopToBottom()
        {
            const string input = @"    a    
         
         
    b    
         
";
            const string expectedValue = @"    *    
    *    
    *    
    *    
         
";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Fact]
        public void DrawVerticalLineFromBottomToTop()
        {
            const string input = @"    b    
         
         
    a    
         
";
            const string expectedValue = @"    *    
    *    
    *    
    *    
         
";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Fact]
        public void DrawDiagonalLineFromTopLeftToBottomRight()
        {
            const string input = @"         
 a       
         
         
         
         
      b  
         ";

            const string expectedValue = @"         
 *       
  *      
   *     
    *    
     *   
      *  
         ";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Fact]
        public void DrawDiagnoalLineFromBottomRightToTopLeft()
        {
            const string input = @"         
 b       
         
         
         
         
      a  
         ";

            const string expectedValue = @"         
 *       
  *      
   *     
    *    
     *   
      *  
         ";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Fact]
        public void DrawDiagonalLineFromTopRightToBottomLeft()
        {
            const string input = @"         
       a 
         
         
         
         
  b      
         ";

            const string expectedValue = @"         
       * 
      *  
     *   
    *    
   *     
  *      
         ";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Fact]
        public void DrawDiagonalLineFromBottomLeftToTopRight()
        {
            const string input = @"         
       b 
         
         
         
         
  a      
         ";

            const string expectedValue = @"         
       * 
      *  
     *   
    *    
   *     
  *      
         ";

            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }

        [Theory]
        [InlineData(
            "           \n" +
            " a       b \n" +
            " e         \n" +
            "           \n" +
            " d       c \n" +
            "           \n",
            "           \n" +
            " ********* \n" +
            " *       * \n" +
            " *       * \n" +
            " ********* \n" +
            "           \n")]
        [InlineData(
            "           \n" +
            "     a     \n" +
            "    e      \n" +
            "           \n" +
            "  d     b  \n" +
            "           \n" +
            "           \n" +
            "     c     \n" +
            "           \n",
            "           \n" +
            "     *     \n" +
            "    * *    \n" +
            "   *   *   \n" +
            "  *     *  \n" +
            "   *   *   \n" +
            "    * *    \n" +
            "     *     \n" +
            "           \n")]
        public void Test1(string input, string expectedValue)
        {
            var sut = new Connector(input);
            sut.Connect();
            Assert.Equal(expectedValue, sut.Picture);
        }
    }
}
