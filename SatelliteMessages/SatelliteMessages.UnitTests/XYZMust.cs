using System;
using System.Linq;
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
        public void Test5()
        {
            var distances = new List<double>() { 854.4003745317531, 282.842712474619, 200 };
            var satellites = new List<(double X, double Y)>() { (-500, -200), (100, -100), (500, 100) };
            var sut = new XYZ(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal(300, result.X, 7);
            Assert.Equal(100, result.Y, 7);
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

            var number = ((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X);
            var number2 = (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X));
            var number3 = (-Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2) - Math.Pow(number, 2));

            var a = Math.Pow(number2, 2) + 1;
            var b = -2 * (number * number2 + _satellites[0].Y);
            var c = -number3;

            var y1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            var x11 = Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y1 - _satellites[0].Y, 2)) + _satellites[0].X);

            double distanceBetweenFirstSatelliteAndSource;
            double distanceBetweenSecondSatelliteAndSource;
            double distanceBetweenThirdSatelliteAndSource;

            distanceBetweenFirstSatelliteAndSource = Math.Sqrt(Math.Pow(x11 - _satellites[0].X, 2) + Math.Pow(y1 - _satellites[0].Y, 2));
            if (Math.Abs(distanceBetweenFirstSatelliteAndSource - distances[0]) < 0.0000001)
            {
                distanceBetweenSecondSatelliteAndSource = Math.Sqrt(Math.Pow(x11 - _satellites[1].X, 2) + Math.Pow(y1 - _satellites[1].Y, 2));
                if (Math.Abs(distanceBetweenSecondSatelliteAndSource - distances[1]) < 0.0000001)
                {
                    distanceBetweenThirdSatelliteAndSource = Math.Sqrt(Math.Pow(x11 - _satellites[2].X, 2) + Math.Pow(y1 - _satellites[2].Y, 2));
                    if (Math.Abs(distanceBetweenThirdSatelliteAndSource - distances[2]) < 0.0000001)
                    {
                        return (x11, y1);
                    }
                }
            }

            var y2 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            var x12 = Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y2 - _satellites[0].Y, 2)) + _satellites[0].X);

            distanceBetweenFirstSatelliteAndSource = Math.Sqrt(Math.Pow(x12 - _satellites[0].X, 2) + Math.Pow(y2 - _satellites[0].Y, 2));
            if (Math.Abs(distanceBetweenFirstSatelliteAndSource - distances[0]) < 0.0000001)
            {
                distanceBetweenSecondSatelliteAndSource = Math.Sqrt(Math.Pow(x12 - _satellites[1].X, 2) + Math.Pow(y2 - _satellites[1].Y, 2));
                if (Math.Abs(distanceBetweenSecondSatelliteAndSource - distances[1]) < 0.0000001)
                {
                    distanceBetweenThirdSatelliteAndSource = Math.Sqrt(Math.Pow(x12 - _satellites[2].X, 2) + Math.Pow(y2 - _satellites[2].Y, 2));
                    if (Math.Abs(distanceBetweenThirdSatelliteAndSource - distances[2]) < 0.0000001)
                    {
                        return (x12, y2);
                    }
                }
            }

            throw new Exception("Could not locate source");
        }
    }
}
