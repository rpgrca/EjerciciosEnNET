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
        }

        [Fact]
        public void Test10()
        {
            Assert.Equal(8, Kata.CountSquares(1));
        }

        [Fact]
        public void Test11()
        {
            Assert.Equal(26, Kata.CountSquares(2));
        }

        [Fact]
        public void Test12()
        {
            Assert.Equal(98, Kata.CountSquares(4));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(152,Kata.CountSquares(5));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(1538, Kata.CountSquares(16));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(3176, Kata.CountSquares(23));
        }
    }
}
