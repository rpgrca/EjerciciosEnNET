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

        /*[Fact]
        public void Test4()
        {
            var distances = new List<double>() { 5, 3, 5 };
            var satellites = new List<(double X, double Y)>() { (4, 2), (1, 9), (4, 10) };
            var sut = new XYZ(satellites);
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 6), result);


            (1, 9) trasladado (4, 2) = (-3, 7) 
            (4, 2) trasladado (4, 2) =  (0, 0)

            calcular distancia de centro a (-3, 7)
            ((0 + 3)^2 + (0 - 7)^2)^1/2 → (9 + 49)^1/2 → 7.61577310586

            (x^2 + y^2)^1/2 = 7.61577310586 → x^2 + y^2 = 58 con y = 0 → x^2 = 58 → 7.61577310586

            - circulo con centro en (0, 0) y radio 5
            - circulo con centro en (-7.61577310586, 0) y radio 3

            entonces

            d = ((0 - -3)^2 + (0 - 7)^2)^1/2 → d = (9 + 49)^1/2 → d = 7.61577310586
            l = (5^2 - 3^2 + 58) / (2 * 7.61577310586) → 74 / 15.2315462117 → l = 4.85833801582
            h = (5^2 - 4.85833801582)^1/2 → 20.1416619842^1/2 → 4.48794629917

            x = (4.85833801582 / 7.61577310586) * (-3 - 0)) +- (4.48794629917 / 7.61577310586) * (7 - 0) + 0 → 0.63793103448 * -3 +- ... → -1.91379310345 +- 0.58929621941 * 7 → -1.91379310345 +- 4.12507353587 ()


        }*/

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

            //var x = 300;
            var y = 100;
            //var distanceBetweenFirstSatelliteAndSource = Math.Sqrt(Math.Pow(x - _satellites[0].X, 2) + Math.Pow(y - _satellites[0].Y, 2));
            //var distanceBetweenSecondSatelliteAndSource = Math.Sqrt(Math.Pow(x - _satellites[1].X, 2) + Math.Pow(y - _satellites[1].Y, 2));

            //Math.Pow(distances[0], 2) == Math.Pow(x - _satellites[0].X, 2) + Math.Pow(y - _satellites[0].Y, 2))

            //Assert.Equal(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2), Math.Pow(x - _satellites[0].X, 2));
            //Assert.Equal(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2)), x - _satellites[0].X, 2);
            //Assert.Equal(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2)) + _satellites[0].X, x);

            var x1 = Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2)) + _satellites[0].X);
            //Assert.Equal(Math.Pow(distances[1], 2), Math.Pow(x - _satellites[1].X, 2) + Math.Pow(y - _satellites[1].Y, 2));
            Assert.Equal(Math.Pow(distances[1], 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2)) + _satellites[0].X) - _satellites[1].X, 2) + Math.Pow(y - _satellites[1].Y, 2));
            Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(y - _satellites[1].Y, 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2)) + _satellites[0].X) - _satellites[1].X, 2));
            Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(y, 2) + (2 * y * _satellites[1].Y) - Math.Pow(_satellites[1].Y, 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y - _satellites[0].Y, 2)) + _satellites[0].X) - _satellites[1].X, 2));
            Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(y, 2) + (2 * y * _satellites[1].Y) - Math.Pow(_satellites[1].Y, 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - (Math.Pow(y, 2) - (2 * y * _satellites[0].Y) + Math.Pow(_satellites[0].Y, 2))) + _satellites[0].X) - _satellites[1].X, 2));
            Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(y, 2) + (2 * y * _satellites[1].Y) - Math.Pow(_satellites[1].Y, 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) + (- Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2))) + _satellites[0].X) - _satellites[1].X, 2));
            Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(y, 2) + (2 * y * _satellites[1].Y) - Math.Pow(_satellites[1].Y, 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2)) + _satellites[0].X) - _satellites[1].X, 2));
            Assert.Equal(Math.Pow(distances[1], 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2)) + _satellites[0].X) - _satellites[1].X, 2) + Math.Pow(y, 2) - (2 * y * _satellites[1].Y) + Math.Pow(_satellites[1].Y, 2));
            Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2), Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2)) + _satellites[0].X) - _satellites[1].X, 2) + Math.Pow(y, 2) - (2 * y * _satellites[1].Y));
            Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2),
                Math.Pow(Math.Round(Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2)) + _satellites[0].X) - _satellites[1].X, 2) + Math.Pow(y, 2) - (2 * y * _satellites[1].Y));

            /*Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2),
                ((Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2)) + _satellites[0].X - _satellites[1].X) * (Math.Sqrt(Math.Pow(distances[0], 2) - Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2)) + _satellites[0].X - _satellites[1].X))
                + Math.Pow(y, 2) - (2 * y * _satellites[1].Y));*/

            /*Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2),
                (
                    ((-Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2))) + 2 * Math.Sqrt(-Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2)) * (_satellites[0].X - _satellites[1].X) + Math.Pow(_satellites[0].X - _satellites[1].X, 2))
                + Math.Pow(y, 2) - (2 * y * _satellites[1].Y));*/

            /*Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2),
                -Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2) + (2 * Math.Sqrt(-Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2)) * (_satellites[0].X - _satellites[1].X)) + Math.Pow(_satellites[0].X - _satellites[1].X, 2) + Math.Pow(y, 2) - (2 * y * _satellites[1].Y));*/

            /*Assert.Equal(Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2),
                +(2 * y * _satellites[0].Y)
                +(2 * Math.Sqrt(-Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2)) * (_satellites[0].X - _satellites[1].X))
                -(2 * y * _satellites[1].Y));*/

            /*Assert.Equal((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2,
                  y * _satellites[0].Y
                + Math.Sqrt(-Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2)) * (_satellites[0].X - _satellites[1].X)
                - y * _satellites[1].Y);*/

            /*Assert.Equal(((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X),
                     Math.Sqrt(-Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2))
                    + y * (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X))
            );*/

            /*Assert.Equal((((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X)) - (y * (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X))),
                     Math.Sqrt(-Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2))
            );*/

            /*var number = (((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X));
            Assert.Equal(
                Math.Pow(number - (y * (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X))), 2),
                     -Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2)
            );*/

            /*var number = (((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X));
            Assert.Equal(
                Math.Pow(number, 2) - 2 * number * (y * (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X))) + Math.Pow(y * (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X)), 2),
                -Math.Pow(y, 2) + (2 * y * _satellites[0].Y) - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2)
            );*/

            /*var number = (((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X));
            double number2 = (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X));
            Assert.Equal(
                Math.Pow(number, 2) - 2 * number * y * number2 - 2 * y * _satellites[0].Y + Math.Pow(y, 2) * (Math.Pow(number2, 2) + 1),
                - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2)
            );*/

            /*
            var number = (((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X));
            var number2 = (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X));
            var number3 = - Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2) - Math.Pow(number, 2);
            Assert.Equal(
                Math.Pow(y, 2) * (Math.Pow(number2, 2) + 1) - 2 * y * (number * number2 + _satellites[0].Y),
                number3
            );
            */

            var number = ((Math.Pow(distances[1], 2) - Math.Pow(_satellites[1].Y, 2) + Math.Pow(_satellites[0].Y, 2) - Math.Pow(distances[0], 2) - Math.Pow(_satellites[0].X - _satellites[1].X, 2)) / 2) / (_satellites[0].X - _satellites[1].X);
            var number2 = (_satellites[0].Y / (_satellites[0].X - _satellites[1].X) - _satellites[1].Y / (_satellites[0].X - _satellites[1].X));
            var number3 = (-Math.Pow(_satellites[0].Y, 2) + Math.Pow(distances[0], 2) - Math.Pow(number, 2));

            //Assert.Equal(0, Math.Pow(y, 2) * (Math.Pow(number2, 2) + 1) - 2 * y * (number * number2 + _satellites[0].Y) - number3);

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
