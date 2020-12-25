using System.Linq.Expressions;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using Xunit;

namespace Day25.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new Door(0);
            sut.GuessLoopSizeWith(17807724);
            Assert.Equal(11, sut.LoopSize);
        }

        [Fact]
        public void Test11()
        {
            var sut = new Card(0);
            sut.GuessLoopSizeWith(5764801);
            Assert.Equal(8, sut.LoopSize);
        }

        [Fact]
        public void Test2()
        {
            var sut = new Door(11);
            Assert.Equal(17807724, sut.PublicKey);
        }

        [Fact]
        public void Test3()
        {
            var sut = new Card(8);
            Assert.Equal(5764801, sut.PublicKey);
        }

        [Fact]
        public void Test4()
        {
            var door = new Door(11);
            var card = new Card(8);

            door.CalculateEncryptionKeyWith(card.PublicKey);
            Assert.Equal(14897079, door.EncryptionKey);
        }

        [Fact]
        public void Test5()
        {
            var door = new Door(11);
            var card = new Card(8);

            card.CalculateEncryptionKeyWith(door.PublicKey);
            Assert.Equal(14897079, card.EncryptionKey);
        }

        [Fact]
        public void SolveFirstPuzzle1()
        {
            var sut = new Door(0);
            sut.GuessLoopSizeWith(5099500);
            Assert.Equal(14665099, sut.LoopSize);
        }

        [Fact]
        public void SolveFirstPuzzle2()
        {
            var sut = new Card(0);
            sut.GuessLoopSizeWith(7648211);
            Assert.Equal(10092352, sut.LoopSize);
        }

        [Fact]
        public void SolveFirstPuzzle()
        {
            var door = new Door(14665099);
            var card = new Card(10092352);

            card.CalculateEncryptionKeyWith(door.PublicKey);
            Assert.Equal(11288669, card.EncryptionKey);
        }
    }

    public class Card
    {
        public long InitialSubject { get; private set; } = 7;
        public long PublicKey { get; private set; }
        public long DoorPublicKey { get; set; }
        public long LoopSize { get; private set; }
        public long EncryptionKey { get; private set; }
        private long Value { get; set; }

        public Card(int loopSize)
        {
            Value = 1;
            LoopSize = loopSize;

            GeneratePublicKey();
        }

        private void GeneratePublicKey()
        {
            for (var index = 0; index < LoopSize; index++)
            {
                Value *= InitialSubject;
                Value %= 20201227;
            }

            PublicKey = Value;
        }

        public void CalculateEncryptionKeyWith(long publicKey)
        {
            Value = 1;
            for (var index = 0; index < LoopSize; index++)
            {
                Value *= publicKey;
                Value %= 20201227;
            }

            EncryptionKey = Value;
        }

        public void GuessLoopSizeWith(long publicKey)
        {
            PublicKey = publicKey;
            Value = 1;
            InitialSubject = 7;
            while (Value != PublicKey)
            {
                LoopSize++;
                Value *= InitialSubject;
                Value %= 20201227;
            }
        }
    }

    public class Door
    {
        public long PublicKey { get; private set; }
        public long InitialSubject { get; private set; } = 7;
        public long CardPublicKey { get; set; }
        public long LoopSize { get; private set; }
        public long Value { get; private set; }
        public long EncryptionKey { get; private set; }

        public Door(int loopSize)
        {
            LoopSize = loopSize;
            Value = 1;
            InitialSubject = 7;

            GeneratePublicKey();
        }

        private void GeneratePublicKey()
        {
            for (var index = 0; index < LoopSize; index++)
            {
                Value *= InitialSubject;
                Value %= 20201227;
            }

            PublicKey = Value;
        }

        public void CalculateEncryptionKeyWith(long publicKey)
        {
            Value = 1;
            for (var index = 0; index < LoopSize; index++)
            {
                Value *= publicKey;
                Value %= 20201227;
            }

            EncryptionKey = Value;
        }

        public void GuessLoopSizeWith(long publicKey)
        {
            PublicKey = publicKey;
            Value = 1;
            InitialSubject = 7;
            while (Value != PublicKey)
            {
                LoopSize++;
                Value *= InitialSubject;
                Value %= 20201227;
            }
        }
    }
}
