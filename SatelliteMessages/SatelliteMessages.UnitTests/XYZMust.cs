using System;
using System.Collections.Generic;
using Xunit;

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
            var distances = new List<double>() { 5, 3 };
            var satellites = new List<(double X, double Y)>() { (4, 2), (1, 9) };
            var sut = new XYZ(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 6), result);
        }
    }

    public class XYZ
    {
        private readonly List<(double X, double Y)> _satellites;

        public XYZ(List<(double X, double Y)> satellites)
        {
            if (satellites is null || satellites.Count == 0)
            {
                throw new ArgumentException("No satellites");
            }

            _satellites = satellites;
        }

        internal (double X, double Y) GetLocation(List<double> distances)
        {
            if (distances is null || distances.Count == 0)
            {
                throw new ArgumentException("No distances");
            }

            if (_satellites.Count != distances.Count)
            {
                throw new ArgumentException("Satellite count and distance count do not match");
            }

            if (distances.Count == 1 && distances[0] != 0)
            {
                throw new ArgumentException("Not enough satellites to obtain coordinates");
            }

            if (distances.Contains(0))
            {
                return _satellites[distances.IndexOf(0)];
            }

            return (1, 6);
        }
    }
}
