using Xunit;
using Day2.Logic;

namespace Day2.UnitTests
{
    public class SubmarineMust
    {
        [Fact]
        public void Test1()
        {
            const string COURSE = @"forward 5";
            var sut = new Submarine(COURSE);

            Assert.Equal(5, sut.HorizontalPosition);
        }

        [Fact]
        public void Test2()
        {
            const string COURSE = @"forward 5
down 5
forward 8";
            var sut = new Submarine(COURSE);

            Assert.Equal(13, sut.HorizontalPosition);
        }

        [Fact]
        public void Test3()
        {
            const string COURSE = @"forward 5
down 5
forward 8
forward 2";
            var sut = new Submarine(COURSE);

            Assert.Equal(15, sut.HorizontalPosition);
        }
    }
}