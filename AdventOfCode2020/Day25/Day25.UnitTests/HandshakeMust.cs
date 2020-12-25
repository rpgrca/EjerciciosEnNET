using Xunit;
using AdventOfCode2020.Day25.Logic;

namespace AdventOfCode2020.Day25.UnitTests
{
    public class HandshakeMust
    {
        [Theory]
        [InlineData(17807724, 11)]
        [InlineData(5764801, 8)]
        [InlineData(7648211, 10092352)]
        [InlineData(5099500, 14665099)]
        public void CalculateLoopSizeCorrectly_WhenPublicKeyIsKnown(long publicKey, long expectedLoopSize)
        {
            var sut = new Handshake(0);
            sut.CalculateLoopSizeWith(publicKey);
            Assert.True(sut.LoopSizeIs(expectedLoopSize));
        }

        [Theory]
        [InlineData(11, 17807724)]
        [InlineData(8, 5764801)]
        public void CalculatePublicKeyCorrectly_WhenLoopSizeIsKnown(long loopSize, long expectedPublicKey)
        {
            var sut = new Handshake(loopSize);
            Assert.Equal(expectedPublicKey, sut.PublicKey);
        }

        [Theory]
        [InlineData(11, 5764801)]
        [InlineData(8, 17807724)]
        public void CalculateEncryptionKey_WhenLoopSizeAndOtherPublicKeyAreKnown(long loopSize, long publicKey)
        {
            var door = new Handshake(loopSize);

            door.CalculateEncryptionKeyWith(publicKey);
            Assert.Equal(14897079, door.EncryptionKey);
        }

        [Theory]
        [InlineData(7648211, 5099500)]
        [InlineData(5099500, 7648211)]
        public void SolveFirstPuzzle(long doorPublicKey, long cardPublicKey)
        {
            var sut = new Handshake(0);
            sut.CalculateLoopSizeWith(doorPublicKey);
            sut.CalculateEncryptionKeyWith(cardPublicKey);
            Assert.Equal(11288669, sut.EncryptionKey);
        }
    }
}