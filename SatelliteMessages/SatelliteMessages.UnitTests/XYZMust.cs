using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using SatelliteMessages.Logic;

namespace SatelliteMessages.UnitTests
{
    public class XYZMust
    {
        [Fact]
        public void ThrowException_WhenSatelliteListIsNull()
        {
            var exception = Assert.Throws<ArgumentException>(() => new XYZ(null));
            Assert.Equal("No satellites", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenSatelliteListIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => new XYZ(new()));
            Assert.Equal("No satellites", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenDistanceListIsEmpty()
        {
            var satellites = new List<(double X, double Y)>() { (1, 1) };
            var distances = new List<double>();

            var sut = new XYZ(satellites);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("No distances", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenDistanceListIsNull()
        {
            var satellites = new List<(double X, double Y)>() { (1, 1) };

            var sut = new XYZ(satellites);
            Assert.Throws<ArgumentException>(() => sut.GetLocation(null));
        }

        [Fact]
        public void Test1()
        {
            var distances = new List<double>() { 10, 20 };
            var satellites = new List<(double X, double Y)>() { (1, 1) };
            var sut = new XYZ(satellites);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("Satellite count and distance count do not match", exception.Message);
        }

        [Fact]
        public void ReturnSameCoordinatesAsSatellite_WhenDistanceIsZero()
        {
            var distances = new List<double>() { 0 };
            var satellites = new List<(double X, double Y)>() { (1, 1) };
            var sut = new XYZ(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 1), result);
        }

        [Fact]
        public void Test2()
        {
            var distances = new List<double>() { 5, 0 };
            var satellites = new List<(double X, double Y)>() { (4, 2), (1, 6) };
            var sut = new XYZ(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 6), result);
        }

        [Fact]
        public void Test3()
        {
            var distances = new List<double>() { 5 };
            var satellites = new List<(double X, double Y)>() { (4, 2) };
            var sut = new XYZ(satellites);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("Not enough satellites to obtain coordinates", exception.Message);
        }

        [Fact]
        public void Test4()
        {
            var distances = new List<double>() { 5, 16.031220000000015, 21.023796437981545 };
            var satellites = new List<(double X, double Y)>() {  (4, 2), (6, 22), (8, 27) };
            var sut = new XYZ(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal(7, result.X, 5);
            Assert.Equal(6, result.Y, 5);
        }

        [Fact]
        public void Test5()
        {
            var distances = new List<double>() { 854.4003745317531, 282.842712474619, 200 };
            var satellites = new List<(double X, double Y)>() { (-500, -200), (100, -100), (500, 100) };
            var sut = new XYZ(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal(300, result.X, 5);
            Assert.Equal(100, result.Y, 5);
        }
    }
}