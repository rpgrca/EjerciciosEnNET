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
            var builder = new SpySystem.Builder()
                .ConnectingTo(null);

            var exception = Assert.Throws<ArgumentException>(() => builder.Build());
            Assert.Equal("No satellites", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenSatelliteListIsEmpty()
        {
            var builder = new SpySystem.Builder()
                .ConnectingTo(new());

            var exception = Assert.Throws<ArgumentException>(() => builder.Build());
            Assert.Equal("No satellites", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenPrecisionIsInvalid()
        {
            var builder = new SpySystem.Builder()
                .WithToleranceOf(-1)
                .ConnectingTo(new List<(double X, double Y)>() { (1, 1) });

            var exception = Assert.Throws<ArgumentException>(() => builder.Build());
            Assert.Equal("Invalid precision", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenDistanceListIsEmpty()
        {
            var sut = CreateSubjectUnderTest();
            var distances = new List<double>();
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("No distances", exception.Message);
        }

        private static SpySystem CreateSubjectUnderTest() =>
            new SpySystem.Builder()
                .WithToleranceOf(0.00001)
                .ConnectingTo(new List<(double X, double Y)>() { (1, 1) })
                .Build();

        [Fact]
        public void ThrowException_WhenDistanceListIsNull()
        {
            var sut = CreateSubjectUnderTest();
            Assert.Throws<ArgumentException>(() => sut.GetLocation(null));
        }

        [Fact]
        public void ThrowException_WhenDistanceCountIsDifferentFromSatelliteCount()
        {
            var sut = CreateSubjectUnderTest();
            var distances = new List<double>() { 10, 20 };
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("Satellite count and distance count do not match", exception.Message);
        }

        [Fact]
        public void ReturnSameCoordinatesAsSatellite_WhenDistanceIsZero()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .ConnectingTo(new List<(double X, double Y)>() { (1, 1) })
                .Build();

            var distances = new List<double>() { 0 };
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 1), result);
        }

        [Fact]
        public void SatelliteCoordinate_WhenSatelliteIsExactlyAboveSource()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .ConnectingTo(new List<(double X, double Y)>() { (4, 2), (1, 6) })
                .Build();

            var distances = new List<double>() { 5, 0 };
            var result = sut.GetLocation(distances);
            Assert.Equal((1, 6), result);
        }

        [Fact]
        public void ThrowException_WhenThereAreNotEnoughSatelliteWorking()
        {
            var sut = new SpySystem.Builder()
                .WithToleranceOf(0.00001)
                .ConnectingTo(new List<(double X, double Y)>() { (4, 2) })
                .Build();

            var distances = new List<double>() { 5 };
            var exception = Assert.Throws<ArgumentException>(() => sut.GetLocation(distances));
            Assert.Equal("Not enough satellites to obtain coordinates", exception.Message);
        }

        [Fact]
        public void CorrectCoordinates_WhenSatellitePositionAndDistanceIntersectInSinglePoint()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .ConnectingTo(new List<(double X, double Y)>() { (4, 2), (6, 22), (8, 27) })
                .Build();

            var distances = new List<double>() { 5, 16.031220000000015, 21.023796437981545 };
            var (x, y) = sut.GetLocation(distances);
            Assert.Equal(7, x, 5);
            Assert.Equal(6, y, 5);
        }

        [Fact]
        public void CorrectCoordinates_WhenSatelliteAreInDesignedPositionsAndIntersectInSinglePoint()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .Build();

            var distances = new List<double>() { 854.4003745317531, 282.842712474619, 200 };
            var (x, y) = sut.GetLocation(distances);
            Assert.Equal(300, x, 5);
            Assert.Equal(100, y, 5);
        }

        [Fact]
        public void CorrectCoordinates_WhenPrecisionIsAdjusted()
        {
            var sut = SpySystem.With
                .MoreTolerantConfiguration()
                .Build();

            var distances = new List<double>() { 424.26, 360.56, 700 };
            var (x, y) = sut.GetLocation(distances);
            Assert.Equal(-200.01, x, 2);
            Assert.Equal(100, y, 2);
        }

        [Fact]
        public void ThrowException_WhenPrecisionLeavesAnswerOut()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .WithToleranceOf(0.001)
                .Build();

            var distances = new List<double>() { 424.26, 360.56, 700 };
            var exception = Assert.Throws<Exception>(() => sut.GetLocation(distances));
            Assert.Equal("Could not locate source", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenMoreMessagesThanSatellitesAreReceived()
        {
            var sut = new SpySystem.Builder()
                .ConnectingTo(new List<(double X, double Y)>() { (-500, -200) })
                .Build();

            var brokenMessages = new List<string[]>()
            {
                new string[] { "", "este", "es", "un", "mensaje" },
                new string[] { "este", "", "un", "mensaje" },
                new string[] { "", "", "es", "", "mensaje" }
            };

            var exception = Assert.Throws<ArgumentException>(() => sut.GetMessage(brokenMessages));
            Assert.Equal("Satellite and message count mismatch", exception.Message);
        }

        [Fact]
        public void ThrowException_WhenSatelliteDoNotReportMessage()
        {
            var sut = SpySystem.With
                .StandardConfiguration(new SpySystem.Builder())
                .Build();

            var brokenMessages = new List<string[]>()
            {
                new string[] { "", "este", "es", "un", "mensaje" },
            };

            var exception = Assert.Throws<ArgumentException>(() => sut.GetMessage(brokenMessages));
            Assert.Equal("Satellite and message count mismatch", exception.Message);
        }

        [Fact]
        public void ReturnMessage_WhenInterceptedMessageHasNoDelayNorEmptySlots()
        {
            var sut = SpySystem.With
                .StandardConfiguration(new SpySystem.Builder())
                .ConnectingTo(new List<(double X, double Y)>() { (-500, -200) })
                .Build();

            var brokenMessages = new List<string[]>()
            {
                new string[] { "esta", "es", "una", "prueba" },
            };

            var message = sut.GetMessage(brokenMessages);
            Assert.Equal("esta es una prueba", message);
        }

        [Fact]
        public void ReturnMessage_WhenMessageComesWithDelay()
        {
            var sut = SpySystem.With
                .StandardConfiguration(new SpySystem.Builder())
                .ConnectingTo(new List<(double X, double Y)>() { (-500, -200) })
                .Build();

            var brokenMessages = new List<string[]>()
            {
                new string[] { "", "", "esta", "es", "una", "prueba", "con", "delay" },
            };

            var message = sut.GetMessage(brokenMessages);
            Assert.Equal("esta es una prueba con delay", message);
        }

        [Fact]
        public void ThrowException_WhenMessagesNullListIsSupplied()
        {
            var sut = SpySystem.With
                .StandardConfiguration(new SpySystem.Builder())
                .Build();

            var exception = Assert.Throws<ArgumentException>(() => sut.GetMessage(null));
            Assert.Equal("Satellite and message count mismatch", exception.Message);
        }

        [Fact]
        public void ReturnMessage_WhenThereIsAFullMessageAlready()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .ConnectingTo(new List<(double X, double Y)>() { (-500, -200), (100, -100) })
                .Build();

            var brokenMessages = new List<string[]>()
            {
                new string[] { "este", "", "un", "mensaje" },
                new string[] { "este", "es", "un", "mensaje" }
            };

            var message = sut.GetMessage(brokenMessages);
            Assert.Equal("este es un mensaje", message);
        }

        [Fact]
        public void ReturnMessage_WhenThereAreBrokenMessagesAndNoDelay()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .ConnectingTo(new List<(double X, double Y)>() { (-500, -200), (100, -100) })
                .Build();

            var brokenMessages = new List<string[]>()
            {
                new string[] { "este", "", "un", "mensaje" },
                new string[] { "este", "es", "", "mensaje" }
            };

            var message = sut.GetMessage(brokenMessages);
            Assert.Equal("este es un mensaje", message);
        }

        [Fact]
        public void ReturnMessage_WhenThereAreBrokenMessagesAndDelay()
        {
            var sut = SpySystem.With
                .StandardConfiguration()
                .Build();

            var brokenMessages = new List<string[]>()
            {
                new string[] { "este", "", "un", "" },
                new string[] { "", "es", "", "mensaje" },
                new string[] { "", "", "", "este", "es", "", "" }
            };

            var message = sut.GetMessage(brokenMessages);
            Assert.Equal("este es un mensaje", message);
        }
    }
}