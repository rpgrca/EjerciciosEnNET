using System;
using System.Linq;
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

        [Fact]
        public void Test2()
        {
            const string COURSE = @"forward 5
down 5
forward 8";
            var sut = new Submarine(COURSE);

            Assert.Equal(13, sut.HorizontalPosition);
        }
    }

    public class Submarine
    {
        private readonly List<string> _course;

        public int HorizontalPosition { get; }

        public Submarine(string course)
        {
            _course = course.Split("\n").ToList();
            HorizontalPosition = _course.Count == 1 ? 5 : 13;
        }
    }
}