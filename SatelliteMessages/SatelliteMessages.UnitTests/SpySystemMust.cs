using System;
using System.Collections.Generic;
using Xunit;
using SatelliteMessages.Logic;

namespace SatelliteMessages.UnitTests
{
    public class SpySystemMust
    {
        [Fact]
        public void ThrowException_WhenSatelliteListIsNull()
        {
            var exception = Assert.Throws<ArgumentException>(() => new SpySystem(null));
            Assert.Equal("No satellites", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenSatelliteListIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => new SpySystem(new()));
            Assert.Equal("No satellites", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenDistanceListIsEmpty()
        {
            var satellites = new List<(double X, double Y)>() { (1, 1) };
            var distances = new List<double>();

            var sut = new SpySystem(satellites);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("No distances", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenDistanceListIsNull()
        {
            var satellites = new List<(double X, double Y)>() { (1, 1) };

            var sut = new SpySystem(satellites);
            Assert.Throws<ArgumentException>(() => sut.GetLocation(null));
        }

        [Fact]
        public void ThrowException_WhenDistanceCountIsDifferentFromSatelliteCount()
        {
            var distances = new List<double>() { 10, 20 };
            var satellites = new List<(double X, double Y)>() { (1, 1) };
            var sut = new SpySystem(satellites);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("Satellite count and distance count do not match", exception.Message);
        }

        [Fact]
        public void ReturnSameCoordinatesAsSatellite_WhenDistanceIsZero()
        {
            var distances = new List<double>() { 0 };
            var satellites = new List<(double X, double Y)>() { (1, 1) };
            var sut = new SpySystem(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 1), result);
        }

        [Fact]
        public void SatelliteCoordinate_WhenSatelliteIsExactlyAboveSource()
        {
            var distances = new List<double>() { 5, 0 };
            var satellites = new List<(double X, double Y)>() { (4, 2), (1, 6) };
            var sut = new SpySystem(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 6), result);
        }

        [Fact]
        public void ThrowException_WhenThereAreNotEnoughSatelliteWorking()
        {
            var distances = new List<double>() { 5 };
            var satellites = new List<(double X, double Y)>() { (4, 2) };
            var sut = new SpySystem(satellites);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("Not enough satellites to obtain coordinates", exception.Message);
        }

        [Fact]
        public void CorrectCoordinates_WhenSatellitePositionAndDistanceIntersectInSinglePoint()
        {
            var distances = new List<double>() { 5, 16.031220000000015, 21.023796437981545 };
            var satellites = new List<(double X, double Y)>() { (4, 2), (6, 22), (8, 27) };
            var sut = new SpySystem(satellites);
            var (x, y) = sut.GetLocation(distances);
            Assert.Equal(7, x, 5);
            Assert.Equal(6, y, 5);
        }

        [Fact]
        public void CorrectCoordinates_WhenSatelliteAreInDesignedPositionsAndIntersectInSinglePoint()
        {
            var distances = new List<double>() { 854.4003745317531, 282.842712474619, 200 };
            var satellites = new List<(double X, double Y)>() { (-500, -200), (100, -100), (500, 100) };
            var sut = new SpySystem(satellites);
            var (x, y) = sut.GetLocation(distances);
            Assert.Equal(300, x, 5);
            Assert.Equal(100, y, 5);
        }

        [Fact]
        public void Test1()
        {
            var satellites = new List<(double X, double Y)>() { (-500, -200) };
            var brokenMessages = new List<string[]>()
            {
                new string[] { "", "este", "es", "un", "mensaje" },
                new string[] { "este", "", "un", "mensaje" },
                new string[] { "", "", "es", "", "mensaje" }
            };

            var sut = new SpySystem(satellites);
            var exception = Assert.Throws<ArgumentException>(() => sut.GetMessage(brokenMessages));
            Assert.Equal("Received more messages than satellites", exception.Message);
        }
    }
}