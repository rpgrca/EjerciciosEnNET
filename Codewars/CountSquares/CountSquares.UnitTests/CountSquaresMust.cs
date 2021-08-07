using System;
using Xunit;
using CountSquares.Logic;

namespace CountSquares.UnitTests
{
    public class CountSquaresMust
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(1, Kata.CountSquares(0));
            Assert.Equal(152,Kata.CountSquares(5));
            Assert.Equal(1538, Kata.CountSquares(16));
            Assert.Equal(3176, Kata.CountSquares(23));
        }
    }
}
