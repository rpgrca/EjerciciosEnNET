using Xunit;
using PrimeNumber.Logic;

namespace PrimeNumber.UnitTests
{
    public class CompositeNumbersBetweenOneAndMust
    {
        [Fact]
        public void CalculateNumbersUntil5()
        {
            var sut = new CompositeNumbersBetweenOneAnd(5);
            Assert.Equal(new [] { 4 }, sut.CompositeNumbers);
        }

        [Fact]
        public void CalculateNumbersUntil10()
        {
            var sut = new CompositeNumbersBetweenOneAnd(10);
            Assert.Equal(new [] { 4, 6, 8, 9, 10 }, sut.CompositeNumbers);
        }

        [Fact]
        public void CalculateNumbersUntil100()
        {
            var sut = new CompositeNumbersBetweenOneAnd(100);
            Assert.Equal(new [] { 4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27, 28, 30, 32, 33, 34, 35, 36, 38, 39, 40, 42, 44, 45, 46, 48, 49, 50, 51, 52, 54, 55, 56, 57, 58, 60, 62, 63, 64, 65, 66, 68, 69, 70, 72, 74, 75, 76, 77, 78, 80, 81, 82, 84, 85, 86, 87, 88, 90, 91, 92, 93, 94, 95, 96, 98, 99, 100 }, sut.CompositeNumbers);
        }

        [Fact]
        public void CalculateNumbersUntil200()
        {
            var sut = new CompositeNumbersBetweenOneAnd(199);
            Assert.Equal(new [] { 4, 6, 8, 9, 10, 12, 14, 15, 16, 18, 20, 21, 22, 24, 25, 26, 27, 28, 30, 32, 33, 34, 35, 36, 38, 39, 40, 42, 44, 45, 46, 48, 49, 50, 51, 52, 54, 55, 56, 57, 58, 60, 62, 63, 64, 65, 66, 68, 69, 70, 72, 74, 75, 76, 77, 78, 80, 81, 82, 84, 85, 86, 87, 88, 90, 91, 92, 93, 94, 95, 96, 98, 99, 100, 102, 104, 105, 106, 108, 110, 111, 112, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 128, 129, 130, 132, 133, 134, 135, 136, 138, 140, 141, 142, 143, 144, 145, 146, 147, 148, 150, 152, 153, 154, 155, 156, 158, 159, 160, 161, 162, 164, 165, 166, 168, 169, 170, 171, 172, 174, 175, 176, 177, 178, 180, 182, 183, 184, 185, 186, 187, 188, 189, 190, 192, 194, 195, 196, 198 }, sut.CompositeNumbers);
        }

        [Fact]
        public void CalculateNumbersUntil1000000()
        {
            var sut = new CompositeNumbersBetweenOneAnd(1000000);
            Assert.Equal(921501, sut.CompositeNumbers.Count);
        }
    }
}