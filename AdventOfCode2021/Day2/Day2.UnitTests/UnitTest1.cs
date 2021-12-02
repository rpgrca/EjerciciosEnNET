using System;
using System.Collections.Generic;
using Xunit;

namespace Day2.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            const string COURSE = @"forward 5";
            var sut = new Submarine(COURSE);

            Assert.Equal(5, sut.HorizontalPosition);
        }

    }

    public class Submarine
    {
        private readonly string _course;

        public int HorizontalPosition { get; } = 5;

        public Submarine(string course)
        {
            _course = course;
        }
    }
}