using System;
using Xunit;
using Day24.Logic;

namespace Day24.UnitTests
{
    public class ArithmeticLogicUnitMust
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ThrowException_WhenInitializedWithInvalidInput(string invalidInstructions)
        {
            var exception = Assert.Throws<ArgumentException>(() => new ArithmeticLogicUnit(invalidInstructions));
            Assert.Equal("Invalid instructions", exception.Message);
        }

        [Fact]
        public void MoveInputValueToRegisterW()
        {
            var sut = new ArithmeticLogicUnit("inp w");
            sut.Input(7);
            sut.Run();
            Assert.Equal(7, sut.W);
        }

        [Fact]
        public void MoveInputValueToRegisterX()
        {
            var sut = new ArithmeticLogicUnit("inp x");
            sut.Input(5);
            sut.Run();
            Assert.Equal(5, sut.X);
        }

        [Fact]
        public void MoveInputValueToRegisterY()
        {
            var sut = new ArithmeticLogicUnit("inp y");
            sut.Input(9);
            sut.Run();
            Assert.Equal(9, sut.Y);
        }

        [Fact]
        public void MoveInputValueToRegisterZ()
        {
            var sut = new ArithmeticLogicUnit("inp z");
            sut.Input(3);
            sut.Run();
            Assert.Equal(3, sut.Z);
        }

        [Theory]
        [InlineData("inp w\ninp x\nmul w x")]
        [InlineData("inp w\ninp y\nmul w y")]
        [InlineData("inp w\ninp z\nmul w z")]
        [InlineData("inp w\nmul w 3")]
        public void MultiplyRegisterWcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(2);
            sut.Input(3);
            sut.Run();
            Assert.Equal(6, sut.W);
        }

        [Theory]
        [InlineData("inp x\ninp w\nmul x w")]
        [InlineData("inp x\ninp y\nmul x y")]
        [InlineData("inp x\ninp z\nmul x z")]
        [InlineData("inp x\nmul x 3")]
        public void MultiplyRegisterXcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(2);
            sut.Input(3);
            sut.Run();
            Assert.Equal(6, sut.X);
        }

        [Theory]
        [InlineData("inp y\ninp w\nmul y w")]
        [InlineData("inp y\ninp x\nmul y x")]
        [InlineData("inp y\ninp z\nmul y z")]
        [InlineData("inp y\nmul y 3")]
        public void MultiplyRegisterYcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(2);
            sut.Input(3);
            sut.Run();
            Assert.Equal(6, sut.Y);
        }

        [Theory]
        [InlineData("inp z\ninp w\nmul z w")]
        [InlineData("inp z\ninp x\nmul z x")]
        [InlineData("inp z\ninp y\nmul z y")]
        [InlineData("inp z\nmul z 3")]
        public void MultiplyRegisterZcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(2);
            sut.Input(3);
            sut.Run();
            Assert.Equal(6, sut.Z);
        }


/*
        [Theory]
        [InlineData(4, 8)]
        public void DuplicateNumberStoredInX(int input, int expectedX)
        {
            var sut = new ArithmeticLogicUnit(@"inp x
mul x 2");
            sut.Input(input);
            Assert.Equal(expectedX, sut.X);
        }

/*
        [Theory]
        [InlineData(4, -4)]
        [InlineData(7, -7)]
        public void NegateInputNumberStoredInX(int input, int expectedX)
        {
            var sut = new ArithmeticLogicUnit(@"inp x
mul x -1");
            sut.Input(input);
            Assert.Equal(expectedX, sut.X);
        }

        [Theory]
        [InlineData(4, 8)]
        public void DuplicateNumberStoredInX(int input, int expectedX)
        {
            var sut = new ArithmeticLogicUnit(@"inp x
mul x 2");
            sut.Input(input);
            Assert.Equal(expectedX, sut.X);
        }
        */
    }
}