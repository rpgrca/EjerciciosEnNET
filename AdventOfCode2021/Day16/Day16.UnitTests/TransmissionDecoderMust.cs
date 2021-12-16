using System;
using Xunit;
using Day16.Logic;
using static Day16.UnitTests.Constants;

namespace Day16.UnitTests
{
    public class TransmissionDecoderMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenTransmissionIsInvalid(string invalidTransmission)
        {
            var exception = Assert.Throws<ArgumentException>(() => new TransmissionDecoder(invalidTransmission));
            Assert.Equal("Invalid transmission", exception.Message);
        }

        [Theory]
        [InlineData("D2FE28", "110", "100")]
        [InlineData("38006F45291200", "001", "110")]
        [InlineData("EE00D40C823060", "111", "011")]
        public void Test1(string transmission, string expectedVersion, string expectedTypeId)
        {
            var sut = new TransmissionDecoder(transmission);
            Assert.Collection(sut.Packets,
                p1 => {
                    Assert.Equal(expectedVersion, p1.Version);
                    Assert.Equal(expectedTypeId, p1.TypeId);
                });
        }

        [Fact]
        public void ParseLiteralPacketsCorrectly()
        {
            var decoder = new TransmissionDecoder("D2FE28");
            var sut = (LiteralPacket)decoder.Packets[0];

            Assert.Equal("110", sut.Version);
            Assert.Equal("100", sut.TypeId);
            Assert.Collection(sut.Groups,
                p1 => Assert.Equal("10111", p1),
                p2 => Assert.Equal("11110", p2),
                p3 => Assert.Equal("00101", p3));
            Assert.Equal(2021, sut.Value);
        }

        [Theory]
        [InlineData("EE00D40C823060", 1)]
        [InlineData("38006F45291200", 0)]
        public void DetectsLengthTypeIdCorrectly_WhenParsingOperatorPacket(string transmission, int expectedLengthTypeId)
        {
            var decoder = new TransmissionDecoder(transmission);
            var sut = (OperatorPacket)decoder.Packets[0];
            Assert.Equal(expectedLengthTypeId, sut.LengthTypeId);
        }

        [Fact]
        public void DetectsSubPacketsLengthInBitsCorrectly()
        {
            var decoder = new TransmissionDecoder("38006F45291200");
            var sut = (OperatorPacket)decoder.Packets[0];

            Assert.Equal(27, sut.SubPacketsLengthInBits);
        }

        [Fact]
        public void ParsesOperatorWithSubPacketsLengthInBitsCorrectly()
        {
            var decoder = new TransmissionDecoder("38006F45291200");
            var sut = (OperatorPacket)decoder.Packets[0];

            Assert.Collection(sut.SubPackets,
                p1 => Assert.Equal(10, ((LiteralPacket)p1).Value),
                p2 => Assert.Equal(20, ((LiteralPacket)p2).Value));
        }

        [Fact]
        public void ParsesOperatorWithSubPacketsCountCorreclty()
        {
            var decoder = new TransmissionDecoder("EE00D40C823060");
            var sut = (OperatorPacket)decoder.Packets[0];

            Assert.Collection(sut.SubPackets,
                p1 => Assert.Equal(1, ((LiteralPacket)p1).Value),
                p2 => Assert.Equal(2, ((LiteralPacket)p2).Value),
                p3 => Assert.Equal(3, ((LiteralPacket)p3).Value));
        }

        [Theory]
        [InlineData("38006F45291200", "0000000")]
        [InlineData("D2FE28", "000")]
        [InlineData("EE00D40C823060", "00000")]
        public void IgnoreEndOfTransmissionCorrectly(string transmission, string expectedIgnored)
        {
            var sut = new TransmissionDecoder(transmission);
            Assert.Equal(expectedIgnored, sut.Ignored);
        }

        [Theory]
        [InlineData("8A004A801A8002F478", 16)]
        [InlineData("620080001611562C8802118E34", 12)]
        [InlineData("C0015000016115A2E0802F182340", 23)]
        [InlineData("A0016C880162017C3686B18A3D4780", 31)]
        public void ReturnVersionSum(string transmission, int expectedVersionSum)
        {
            var sut = new TransmissionDecoder(transmission);
            Assert.Equal(expectedVersionSum, sut.GetVersionSum());
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var sut = new TransmissionDecoder(REAL_TRANSMISSION);
            Assert.Equal(897, sut.GetVersionSum());
        }

        [Theory]
        [InlineData("C200B40A82", 3L)]
        public void ExecuteOperatorCorrectly(string transmission, long expectedValue)
        {
            var sut = new TransmissionDecoder(transmission);
            Assert.Equal(expectedValue, sut.Value);
        }
    }
}