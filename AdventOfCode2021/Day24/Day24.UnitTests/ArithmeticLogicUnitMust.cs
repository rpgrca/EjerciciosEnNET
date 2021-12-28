
using System;
using Xunit;
using Day24.Logic;

namespace Day24.UnitTests
{
    public partial class ArithmeticLogicUnitMust
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
        [InlineData(4, 8)]
        public void DuplicateNumberStoredInX(int input, int expectedX)
        {
            var sut = new ArithmeticLogicUnit(@"inp x
mul x 2");
            sut.Input(input);
            sut.Run();
            Assert.Equal(expectedX, sut.X);
        }

        [Theory]
        [InlineData(4, -4)]
        [InlineData(7, -7)]
        public void NegateInputNumberStoredInX(int input, int expectedX)
        {
            var sut = new ArithmeticLogicUnit(@"inp x
mul x -1");
            sut.Input(input);
            sut.Run();
            Assert.Equal(expectedX, sut.X);
        }

        [Theory]
        [InlineData("inp w\ninp x\nmul w 3\neql w x", 10, 30, 1)]
        [InlineData("inp w\ninp x\nmul w 3\neql w x", 30, 10, 0)]
        public void VerifyWhetherAvalueIsTripleTheOtherWithRegisterW(string instructions, int firstInput, int secondInput, int expectedResult)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(firstInput);
            sut.Input(secondInput);
            sut.Run();
            Assert.Equal(expectedResult, sut.W);
        }

        [Theory]
        [InlineData("inp x\ninp y\nmul x 3\neql x y", 10, 30, 1)]
        [InlineData("inp x\ninp y\nmul x 3\neql x y", 30, 10, 0)]
        public void VerifyWhetherAvalueIsTripleTheOtherWithRegisterX(string instructions, int firstInput, int secondInput, int expectedResult)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(firstInput);
            sut.Input(secondInput);
            sut.Run();
            Assert.Equal(expectedResult, sut.X);
        }

        [Theory]
        [InlineData("inp y\ninp x\nmul y 3\neql y x", 10, 30, 1)]
        [InlineData("inp y\ninp x\nmul y 3\neql y x", 30, 10, 0)]
        public void VerifyWhetherAvalueIsTripleTheOtherWithRegisterY(string instructions, int firstInput, int secondInput, int expectedResult)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(firstInput);
            sut.Input(secondInput);
            sut.Run();
            Assert.Equal(expectedResult, sut.Y);
        }

        [Theory]
        [InlineData("inp z\ninp x\nmul z 3\neql z x", 10, 30, 1)]
        [InlineData("inp z\ninp x\nmul z 3\neql z x", 30, 10, 0)]
        public void VerifyWhetherAvalueIsTripleTheOtherWithRegisterZ(string instructions, int firstInput, int secondInput, int expectedResult)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(firstInput);
            sut.Input(secondInput);
            sut.Run();
            Assert.Equal(expectedResult, sut.Z);
        }
    }
}