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

        [Theory]
        [InlineData("inp w\ninp x\nadd w x")]
        [InlineData("inp w\ninp y\nadd w y")]
        [InlineData("inp w\ninp z\nadd w z")]
        [InlineData("inp w\nadd w 6")]
        public void AddRegisterWcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(5);
            sut.Input(6);
            sut.Run();
            Assert.Equal(11, sut.W);
        }

        [Theory]
        [InlineData("inp x\ninp w\nadd x w")]
        [InlineData("inp x\ninp y\nadd x y")]
        [InlineData("inp x\ninp z\nadd x z")]
        [InlineData("inp x\nadd x 6")]
        public void AddRegisterXcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(5);
            sut.Input(6);
            sut.Run();
            Assert.Equal(11, sut.X);
        }

        [Theory]
        [InlineData("inp y\ninp w\nadd y w")]
        [InlineData("inp y\ninp x\nadd y x")]
        [InlineData("inp y\ninp z\nadd y z")]
        [InlineData("inp y\nadd y 6")]
        public void AddRegisterYcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(5);
            sut.Input(6);
            sut.Run();
            Assert.Equal(11, sut.Y);
        }

        [Theory]
        [InlineData("inp z\ninp w\nadd z w")]
        [InlineData("inp z\ninp x\nadd z x")]
        [InlineData("inp z\ninp y\nadd z y")]
        [InlineData("inp z\nadd z 6")]
        public void AddRegisterZcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(5);
            sut.Input(6);
            sut.Run();
            Assert.Equal(11, sut.Z);
        }

        [Theory]
        [InlineData("inp w\ninp x\ndiv w x")]
        [InlineData("inp w\ninp y\ndiv w y")]
        [InlineData("inp w\ninp z\ndiv w z")]
        [InlineData("inp w\ndiv w 6")]
        public void DivideRegisterWcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(6);
            sut.Run();
            Assert.Equal(2, sut.W);
        }

        [Theory]
        [InlineData("inp x\ninp w\ndiv x w")]
        [InlineData("inp x\ninp y\ndiv x y")]
        [InlineData("inp x\ninp z\ndiv x z")]
        [InlineData("inp x\ndiv x 6")]
        public void DivideRegisterXcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(6);
            sut.Run();
            Assert.Equal(2, sut.X);
        }

        [Theory]
        [InlineData("inp y\ninp w\ndiv y w")]
        [InlineData("inp y\ninp x\ndiv y x")]
        [InlineData("inp y\ninp z\ndiv y z")]
        [InlineData("inp y\ndiv y 6")]
        public void DivideRegisterYcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(6);
            sut.Run();
            Assert.Equal(2, sut.Y);
        }

        [Theory]
        [InlineData("inp z\ninp w\ndiv z w")]
        [InlineData("inp z\ninp x\ndiv z x")]
        [InlineData("inp z\ninp y\ndiv z y")]
        [InlineData("inp z\ndiv z 6")]
        public void DivideRegisterZcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(6);
            sut.Run();
            Assert.Equal(2, sut.Z);
        }

        [Theory]
        [InlineData("inp w\ninp x\nmod w x")]
        [InlineData("inp w\ninp y\nmod w y")]
        [InlineData("inp w\ninp z\nmod w z")]
        [InlineData("inp w\nmod w 7")]
        public void LeaveRemainderInRegisterWcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(7);
            sut.Run();
            Assert.Equal(5, sut.W);
        }

        [Theory]
        [InlineData("inp x\ninp w\nmod x w")]
        [InlineData("inp x\ninp y\nmod x y")]
        [InlineData("inp x\ninp z\nmod x z")]
        [InlineData("inp x\nmod x 7")]
        public void LeaveRemainderInRegisterXcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(7);
            sut.Run();
            Assert.Equal(5, sut.X);
        }

        [Theory]
        [InlineData("inp y\ninp w\nmod y w")]
        [InlineData("inp y\ninp x\nmod y x")]
        [InlineData("inp y\ninp z\nmod y z")]
        [InlineData("inp y\nmod y 7")]
        public void LeaveRemainderInRegisterYcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(7);
            sut.Run();
            Assert.Equal(5, sut.Y);
        }

        [Theory]
        [InlineData("inp z\ninp w\nmod z w")]
        [InlineData("inp z\ninp x\nmod z x")]
        [InlineData("inp z\ninp y\nmod z y")]
        [InlineData("inp z\nmod z 7")]
        public void LeaveRemainderInRegisterZcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(12);
            sut.Input(7);
            sut.Run();
            Assert.Equal(5, sut.Z);
        }

        [Theory]
        [InlineData(15, 1, 1, 1, 1)]
        [InlineData(14, 0, 1, 1, 1)]
        [InlineData(13, 1, 0, 1, 1)]
        [InlineData(12, 0, 0, 1, 1)]
        [InlineData(11, 1, 1, 0, 1)]
        [InlineData(10, 0, 1, 0, 1)]
        [InlineData(9, 1, 0, 0, 1)]
        [InlineData(8, 0, 0, 0, 1)]
        [InlineData(7, 1, 1, 1, 0)]
        [InlineData(6, 0, 1, 1, 0)]
        [InlineData(5, 1, 0, 1, 0)]
        [InlineData(4, 0, 0, 1, 0)]
        [InlineData(3, 1, 1, 0, 0)]
        [InlineData(2, 0, 1, 0, 0)]
        [InlineData(1, 1, 0, 0, 0)]
        [InlineData(0, 0, 0, 0, 0)]
        public void ConvertValueToBinary(int value, int expectedZ, int expectedY, int expectedX, int expectedW)
        {
            var sut = new ArithmeticLogicUnit(@"inp w
add z w
mod z 2
div w 2
add y w
mod y 2
div w 2
add x w
mod x 2
div w 2
mod w 2");
            sut.Input(value);
            sut.Run();
            Assert.Equal(expectedZ, sut.Z);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedW, sut.W);
        }
    }
}