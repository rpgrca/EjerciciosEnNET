using System;
using Xunit;
using Day24.Logic;
using static Day24.UnitTests.Constants;

namespace Day24.UnitTests
{
    public class ArithmeticLogicUnitMust
    {
        private const string FIVE_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y";
        private const string THIRTEEN_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -1
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -16
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 0
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 0
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -4
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y";
        private const string THREE_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y";
        private const string ONE_LOOP_INSTRUCTION = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y";
        private const string TWO_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y";
        private const string FOUR_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y";
        private const string SIX_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y";
        private const string SEVEN_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -1
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y";
        private const string EIGHT_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -1
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -16
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y";
        private const string NINE_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -1
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -16
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y";
        private const string TEN_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -1
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -16
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y";
        private const string ELEVEN_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -1
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -16
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 0
mul y x
add z y";
        private const string TWELVE_LOOP_INSTRUCTIONS = @"inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 14
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -9
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 12
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -7
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -1
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 11
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -16
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 15
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 11
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 10
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 26
add x -15
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 2
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 10
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 0
mul y x
add z y
inp w
mul x 0
add x z
mod x 26
div z 1
add x 12
eql x w
eql x 0
mul y 0
add y 25
mul y x
add y 1
mul z y
mul y 0
add y w
add y 0
mul y x
add z y";

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

        [Theory]
        [InlineData(1,   1, 1, 16, 16)] // everything is 16..24
        [InlineData(2,   2, 1, 17, 17)]
        [InlineData(3,   3, 1, 18, 18)]
        [InlineData(4,   4, 1, 19, 19)]
        [InlineData(5,   5, 1, 20, 20)]
        [InlineData(6,   6, 1, 21, 21)]
        [InlineData(7,   7, 1, 22, 22)]
        [InlineData(8,   8, 1, 23, 23)]
        [InlineData(9,   9, 1, 24, 24)]
        public void RunFirstSectionOfMonadCode(int inputValue, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(ONE_LOOP_INSTRUCTION);
            sut.Input(inputValue);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(1, 1,   1, 1, 13, 429)]
        [InlineData(2, 1,   1, 1, 13, 455)]
        [InlineData(3, 1,   1, 1, 13, 481)]
        [InlineData(4, 1,   1, 1, 13, 507)]
        [InlineData(5, 1,   1, 1, 13, 533)]
        [InlineData(6, 1,   1, 1, 13, 559)]
        [InlineData(7, 1,   1, 1, 13, 585)]
        [InlineData(8, 1,   1, 1, 13, 611)]
        [InlineData(9, 1,   1, 1, 13, 637)]
        [InlineData(9, 2,   2, 1, 14, 638)]
        [InlineData(9, 3,   3, 1, 15, 639)]
        [InlineData(9, 4,   4, 1, 16, 640)]
        [InlineData(9, 5,   5, 1, 17, 641)]
        [InlineData(9, 6,   6, 1, 18, 642)]
        [InlineData(9, 7,   7, 1, 19, 643)]
        [InlineData(9, 8,   8, 1, 20, 644)]
        [InlineData(9, 9,   9, 1, 21, 645)] // 99 z = 645
        public void RunSecondSectionOfMonadCode(int firstInput, int secondInput, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(TWO_LOOP_INSTRUCTIONS);
            sut.Input(firstInput);
            sut.Input(secondInput);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(1, 1, 1,   1, 1, 16, 11170)]
        [InlineData(1, 1, 2,   2, 1, 17, 11171)]
        [InlineData(9, 1, 1,   1, 1, 16, 16578)]
        [InlineData(9, 9, 1,   1, 1, 16, 16786)]
        [InlineData(9, 9, 2,   2, 1, 17, 16787)]
        [InlineData(9, 9, 3,   3, 1, 18, 16788)] // biggest number which mod 26 between 10 and 18
        [InlineData(9, 9, 6,   6, 1, 21, 16791)]
        [InlineData(9, 9, 7,   7, 1, 22, 16792)]
        [InlineData(9, 9, 8,   8, 1, 23, 16793)]
        [InlineData(9, 9, 9,   9, 1, 24, 16794)]
        public void RunThirdSectionOfMonadCode(int firstInput, int secondInput, int thirdInput, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(THREE_LOOP_INSTRUCTIONS);
            sut.Input(firstInput);
            sut.Input(secondInput);
            sut.Input(thirdInput);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(1, 1, 1, 1,   1, 1, 13, 11167)]
        [InlineData(9, 9, 1, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 1, 6,   6, 1, 18, 16788)]
        [InlineData(9, 9, 1, 7,   7, 0, 0, 645)] // 9917, z = 645
        [InlineData(9, 9, 1, 8,   8, 1, 20, 16790)]
        [InlineData(9, 9, 1, 9,   9, 1, 21, 16791)]
        [InlineData(9, 9, 2, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 2, 8,   8, 0, 0, 645)]
        [InlineData(9, 9, 3, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 3, 2,   2, 1, 14, 16784)]
        [InlineData(9, 9, 3, 3,   3, 1, 15, 16785)]
        [InlineData(9, 9, 3, 4,   4, 1, 16, 16786)]
        [InlineData(9, 9, 3, 5,   5, 1, 17, 16787)]
        [InlineData(9, 9, 3, 6,   6, 1, 18, 16788)]
        [InlineData(9, 9, 3, 7,   7, 1, 19, 16789)]
        [InlineData(9, 9, 3, 8,   8, 1, 20, 16790)]
        [InlineData(9, 9, 3, 9,   9, 0, 0, 645)] // 9939, z = 645, highest number confirmed
        [InlineData(9, 9, 4, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 5, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 6, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 7, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 8, 1,   1, 1, 13, 16783)]
        [InlineData(9, 9, 9, 1,   1, 1, 13, 16783)]
        public void RunFourthSectionOfMonadCode(int firstInput, int secondInput, int thirdInput, int fourthInput, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(FOUR_LOOP_INSTRUCTIONS);

            sut.Input(firstInput);
            sut.Input(secondInput);
            sut.Input(thirdInput);
            sut.Input(fourthInput);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
       }

        [Theory]
        [InlineData(1, 1, 1, 1, 1,  1, 1, 16, 11170)]
        [InlineData(9, 4, 3, 9, 9,  9, 0, 0, 24)] // 94399
        [InlineData(9, 9, 1, 6, 9,  9, 1, 24, 16794)]
        [InlineData(9, 9, 1, 7, 1,  1, 1, 16, 640)]
        [InlineData(9, 9, 1, 7, 2,  2, 1, 17, 641)]
        [InlineData(9, 9, 1, 7, 3,  3, 1, 18, 642)]
        [InlineData(9, 9, 1, 7, 4,  4, 1, 19, 643)]
        [InlineData(9, 9, 1, 7, 5,  5, 1, 20, 644)]
        [InlineData(9, 9, 1, 7, 6,  6, 1, 21, 645)]
        [InlineData(9, 9, 1, 7, 7,  7, 1, 22, 646)]
        [InlineData(9, 9, 1, 7, 8,  8, 1, 23, 647)]
        [InlineData(9, 9, 1, 7, 9,  9, 1, 24, 648)]
        [InlineData(9, 9, 1, 8, 1,  1, 1, 16, 16786)]
        [InlineData(9, 9, 3, 9, 1,  1, 1, 16, 640)]
        [InlineData(9, 9, 3, 9, 2,  2, 1, 17, 641)]
        [InlineData(9, 9, 3, 9, 3,  3, 1, 18, 642)]
        [InlineData(9, 9, 3, 9, 4,  4, 1, 19, 643)]
        [InlineData(9, 9, 3, 9, 5,  5, 1, 20, 644)]
        [InlineData(9, 9, 3, 9, 6,  6, 1, 21, 645)]
        [InlineData(9, 9, 3, 9, 7,  7, 1, 22, 646)]
        [InlineData(9, 9, 3, 9, 8,  8, 1, 23, 647)]
        [InlineData(9, 9, 3, 9, 9,  9, 1, 24, 648)]
        [InlineData(9, 9, 4, 1, 1,  1, 1, 16, 16786)]
        [InlineData(9, 9, 9, 9, 9,  9, 1, 24, 16794)]
        public void RunFifthSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(FIVE_LOOP_INSTRUCTIONS);

            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(9, 4, 3, 9, 8, 9,   9, 1, 11, 16833)]
        [InlineData(9, 4, 3, 9, 9, 1,   1, 1, 3, 627)] // 943991..943999
        [InlineData(9, 4, 3, 9, 9, 2,   2, 1, 4, 628)]
        [InlineData(9, 4, 3, 9, 9, 3,   3, 1, 5, 629)]
        [InlineData(9, 4, 3, 9, 9, 4,   4, 1, 6, 630)]
        [InlineData(9, 4, 3, 9, 9, 5,   5, 1, 7, 631)]
        [InlineData(9, 4, 3, 9, 9, 6,   6, 1, 8, 632)]
        [InlineData(9, 4, 3, 9, 9, 7,   7, 1, 9, 633)]
        [InlineData(9, 4, 3, 9, 9, 8,   8, 1, 10, 634)]
        [InlineData(9, 4, 3, 9, 9, 9,   9, 1, 11, 635)]
        [InlineData(9, 4, 4, 1, 1, 1,   1, 1, 3, 433059)]
        [InlineData(9, 9, 1, 6, 9, 9,   9, 1, 11, 436655)]
        [InlineData(9, 9, 1, 7, 1, 1,   1, 1, 3, 16643)]
        [InlineData(9, 9, 1, 7, 1, 2,   2, 1, 4, 16644)]
        [InlineData(9, 9, 1, 7, 1, 9,   9, 1, 11, 16651)]
        [InlineData(9, 9, 1, 7, 2, 1,   1, 1, 3, 16669)]
        [InlineData(9, 9, 1, 7, 2, 2,   2, 1, 4, 16670)]
        [InlineData(9, 9, 1, 7, 2, 7,   7, 1, 9, 16675)]
        [InlineData(9, 9, 1, 7, 2, 9,   9, 1, 11, 16677)]
        [InlineData(9, 9, 1, 7, 3, 9,   9, 1, 11, 16703)]
        [InlineData(9, 9, 1, 7, 4, 9,   9, 1, 11, 16729)]
        [InlineData(9, 9, 1, 7, 5, 9,   9, 1, 11, 16755)]
        [InlineData(9, 9, 1, 7, 6, 9,   9, 1, 11, 16781)]
        [InlineData(9, 9, 1, 7, 7, 1,   1, 1, 3, 16799)]
        [InlineData(9, 9, 1, 7, 8, 1,   1, 1, 3, 16825)]
        [InlineData(9, 9, 1, 7, 9, 1,   1, 1, 3, 16851)]
        [InlineData(9, 9, 1, 7, 9, 9,   9, 1, 11, 16859)]
        [InlineData(9, 9, 3, 8, 9, 9,   9, 1, 11, 436655)]
        [InlineData(9, 9, 3, 9, 1, 1,   1, 1, 3, 16643)]
        [InlineData(9, 9, 3, 9, 8, 9,   9, 1, 11, 16833)]
        [InlineData(9, 9, 3, 9, 9, 1,   1, 1, 3, 16851)]
        [InlineData(9, 9, 3, 9, 9, 2,   2, 1, 4, 16852)]
        [InlineData(9, 9, 3, 9, 9, 3,   3, 1, 5, 16853)]
        [InlineData(9, 9, 3, 9, 9, 4,   4, 1, 6, 16854)]
        [InlineData(9, 9, 3, 9, 9, 5,   5, 1, 7, 16855)]
        [InlineData(9, 9, 3, 9, 9, 6,   6, 1, 8, 16856)]
        [InlineData(9, 9, 3, 9, 9, 7,   7, 1, 9, 16857)]
        [InlineData(9, 9, 3, 9, 9, 8,   8, 1, 10, 16858)]
        [InlineData(9, 9, 3, 9, 9, 9,   9, 1, 11, 16859)]
        [InlineData(9, 9, 1, 8, 1, 9,   9, 1, 11, 436447)]
        public void RunSixthSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(SIX_LOOP_INSTRUCTIONS);

            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]

        [InlineData(9, 4, 3, 9, 9, 1, 1,   1, 1, 12, 636)]
        [InlineData(9, 4, 3, 9, 9, 8, 9,   9, 0, 0, 24)] // 9439989
        [InlineData(9, 4, 3, 9, 9, 9, 1,   1, 1, 12, 636)]
        [InlineData(9, 4, 3, 9, 9, 9, 2,   2, 1, 13, 637)]
        [InlineData(9, 4, 3, 9, 9, 9, 3,   3, 1, 14, 638)]
        [InlineData(9, 4, 3, 9, 9, 9, 4,   4, 1, 15, 639)]
        [InlineData(9, 4, 3, 9, 9, 9, 5,   5, 1, 16, 640)]
        [InlineData(9, 4, 3, 9, 9, 9, 6,   6, 1, 17, 641)]
        [InlineData(9, 4, 3, 9, 9, 9, 7,   7, 1, 18, 642)]
        [InlineData(9, 4, 3, 9, 9, 9, 8,   8, 1, 19, 643)]
        [InlineData(9, 4, 3, 9, 9, 9, 9,   9, 1, 20, 644)]
        [InlineData(9, 9, 1, 6, 9, 9, 9,   9, 1, 20, 436664)]
        [InlineData(9, 9, 1, 7, 1, 1, 1,   1, 1, 12, 16652)]
        [InlineData(9, 9, 1, 7, 1, 1, 3,   3, 1, 14, 16654)]
        [InlineData(9, 9, 1, 7, 1, 2, 1,   1, 1, 12, 16652)]
        [InlineData(9, 9, 1, 7, 1, 9, 1,   1, 1, 12, 16652)]
        [InlineData(9, 9, 1, 7, 1, 9, 6,   6, 1, 17, 16657)]
        [InlineData(9, 9, 1, 7, 9, 9, 9,   9, 1, 20, 16868)]
        [InlineData(9, 9, 1, 8, 1, 1, 1,   1, 1, 12, 436448)]
        [InlineData(9, 9, 1, 8, 1, 9, 9,   9, 1, 20, 436456)]
        [InlineData(9, 9, 3, 8, 9, 9, 9,   9, 1, 20, 436664)]
        [InlineData(9, 9, 3, 9, 1, 1, 1,   1, 1, 12, 16652)]
        [InlineData(9, 9, 3, 9, 8, 9, 9,   9, 1, 20, 16842)]
        [InlineData(9, 9, 3, 9, 9, 8, 9,   9, 0, 0, 648)]
        [InlineData(9, 9, 3, 9, 9, 9, 9,   9, 1, 20, 16868)]
        [InlineData(9, 9, 4, 1, 1, 1, 1,   1, 1, 12, 436448)]
        public void RunSeventhSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(SEVEN_LOOP_INSTRUCTIONS);

            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 1,   1, 1, 16, 16)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 2,   2, 1, 17, 17)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 3,   3, 1, 18, 18)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 4,   4, 1, 19, 19)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 5,   5, 1, 20, 20)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 6,   6, 1, 21, 21)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 7,   7, 1, 22, 22)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8,   8, 0, 0, 0)] // 94399898
        [InlineData(9, 4, 3, 9, 9, 8, 9, 9,   9, 1, 24, 24)]
        [InlineData(9, 9, 1, 6, 9, 9, 9, 9,   9, 1, 24, 436668)]
        [InlineData(9, 9, 1, 7, 1, 1, 1, 1,   1, 1, 16, 16656)]
        [InlineData(9, 9, 1, 7, 1, 1, 1, 2,   2, 1, 17, 16657)]
        [InlineData(9, 9, 1, 7, 1, 9, 6, 1,   1, 0, 0, 640)]
        [InlineData(9, 9, 1, 7, 1, 9, 6, 6,   6, 1, 21, 16661)]
        [InlineData(9, 9, 1, 7, 9, 9, 9, 3,   3, 1, 18, 16866)]
        [InlineData(9, 9, 1, 7, 9, 9, 9, 4,   4, 0, 0, 648)]
        [InlineData(9, 9, 1, 7, 9, 9, 9, 5,   5, 1, 20, 16868)]
        [InlineData(9, 9, 1, 7, 9, 9, 9, 9,   9, 1, 24, 16872)]
        [InlineData(9, 9, 1, 8, 1, 1, 1, 1,   1, 1, 16, 436452)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 1,   1, 1, 16, 640)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 2,   2, 1, 17, 641)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 3,   3, 1, 18, 642)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 4,   4, 1, 19, 643)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 5,   5, 1, 20, 644)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 6,   6, 1, 21, 645)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 7,   7, 1, 22, 646)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8,   8, 0, 0, 24)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 9,   9, 1, 24, 648)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4,   4, 0, 0, 648)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 5,   5, 1, 20, 16868)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 6,   6, 1, 21, 16869)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 7,   7, 1, 22, 16870)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 8,   8, 1, 23, 16871)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 9,   9, 1, 24, 16872)]
        [InlineData(9, 9, 4, 1, 1, 1, 1, 1,   1, 1, 16, 436452)]
        public void RunEighthSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(EIGHT_LOOP_INSTRUCTIONS);
            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Input(i8);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 7, 9,   9, 1, 19, 591)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 1,   1, 1, 11, 11)] // 943998981..943998989
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 2,   2, 1, 12, 12)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 3,   3, 1, 13, 13)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 4,   4, 1, 14, 14)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 5,   5, 1, 15, 15)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 6,   6, 1, 16, 16)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 7,   7, 1, 17, 17)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 8,   8, 1, 18, 18)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9,   9, 1, 19, 19)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 9, 1,   1, 1, 11, 635)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 7, 9,   9, 1, 19, 16815)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 1,   1, 1, 11, 635)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 2,   2, 1, 12, 636)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 3,   3, 1, 13, 637)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 4,   4, 1, 14, 638)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 5,   5, 1, 15, 639)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 6,   6, 1, 16, 640)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 7,   7, 1, 17, 641)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 8,   8, 1, 18, 642)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9,   9, 1, 19, 643)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 9, 1,   1, 1, 11, 16859)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 3, 9,   9, 1, 19, 438535)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 1,   1, 1, 11, 16859)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 2,   2, 1, 12, 16860)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 3,   3, 1, 13, 16861)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 4,   4, 1, 14, 16862)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 5,   5, 1, 15, 16863)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 6,   6, 1, 16, 16864)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 7,   7, 1, 17, 16865)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 8,   8, 1, 18, 16866)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9,   9, 1, 19, 16867)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 5, 1,   1, 1, 11, 438579)]
        public void RunNinthSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(NINE_LOOP_INSTRUCTIONS);
            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Input(i8);
            sut.Input(i9);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 7, 9, 9,   9, 1, 11, 583)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 1, 1,   1, 1, 3, 3)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 1, 9,   9, 1, 11, 11)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 2, 1,   1, 1, 3, 3)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4,   4, 0, 0, 0)] // 9439989894
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 9,   9, 1, 11, 11)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 1, 1,   1, 1, 3, 627)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 2, 9,   9, 1, 11, 635)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 3, 1,   1, 1, 3, 627)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 3, 3,   3, 1, 5, 629)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 6, 1,   1, 0, 0, 24)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 6, 2,   2, 1, 4, 628)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 6, 3,   3, 1, 5, 629)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 6, 4,   4, 1, 6, 630)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 6, 5,   5, 1, 7, 631)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 7, 1,   1, 1, 3, 627)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 7, 2,   2, 0, 0, 24)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 8, 3,   3, 0, 0, 24)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4,   4, 0, 0, 24)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 3, 9, 9,   9, 1, 11, 438527)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 1, 1,   1, 1, 3, 16851)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 3,   3, 1, 5, 16853)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4,   4, 0, 0, 648)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 5,   5, 1, 7, 16855)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 9,   9, 1, 11, 16859)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 5, 1, 1,   1, 1, 3, 438571)]
        public void RunTenthSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(TEN_LOOP_INSTRUCTIONS);

            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Input(i8);
            sut.Input(i9);
            sut.Input(i10);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 3, 9,   9, 1, 9, 139)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1,   1, 1, 1, 1)] // 94399898941..94399898949
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 2,   2, 1, 2, 2)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 3,   3, 1, 3, 3)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 4,   4, 1, 4, 4)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 5,   5, 1, 5, 5)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 6,   6, 1, 6, 6)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 7,   7, 1, 7, 7)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 8,   8, 1, 8, 8)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9,   9, 1, 9, 9)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 5, 1,   1, 1, 1, 183)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 3, 9,   9, 1, 9, 16363)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 1,   1, 1, 1, 625)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 2,   2, 1, 2, 626)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 3,   3, 1, 3, 627)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 4,   4, 1, 4, 628)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 5,   5, 1, 5, 629)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 6,   6, 1, 6, 630)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 7,   7, 1, 7, 631)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 8,   8, 1, 8, 632)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9,   9, 1, 9, 633)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 5, 1,   1, 1, 1, 16407)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 3, 9,   9, 1, 9, 438187)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1,   1, 1, 1, 16849)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 2,   2, 1, 2, 16850)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 3,   3, 1, 3, 16851)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 4,   4, 1, 4, 16852)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 5,   5, 1, 5, 16853)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 6,   6, 1, 6, 16854)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 7,   7, 1, 7, 16855)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 8,   8, 1, 8, 16856)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9,   9, 1, 9, 16857)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 5, 1,   1, 1, 1, 438231)]
        public void RunEleventhSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(ELEVEN_LOOP_INSTRUCTIONS);

            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Input(i8);
            sut.Input(i9);
            sut.Input(i10);
            sut.Input(i11);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 1,   1, 1, 1, 27)] // 943998989411..943998989499
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 2,   2, 1, 2, 28)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 3,   3, 1, 3, 29)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 4,   4, 1, 4, 30)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5,   5, 1, 5, 31)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 1,   1, 1, 1, 235)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9,   9, 1, 9, 243)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 1, 1,   1, 1, 1, 16251)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9,   9, 1, 9, 16467)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 3, 9, 9,   9, 1, 9, 11392871)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 1,   1, 1, 1, 438075)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 2,   2, 1, 2, 438076)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 3,   3, 1, 3, 438077)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 4,   4, 1, 4, 438078)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 5,   5, 1, 5, 438079)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 6,   6, 1, 6, 438080)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 7,   7, 1, 7, 438081)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 8,   8, 1, 8, 438082)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 9,   9, 1, 9, 438083)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 2, 1,   1, 1, 1, 438101)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 3, 1,   1, 1, 1, 438127)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 4, 1,   1, 1, 1, 438153)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 5, 1,   1, 1, 1, 438179)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 6, 1,   1, 1, 1, 438205)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 7, 1,   1, 1, 1, 438231)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 8, 1,   1, 1, 1, 438257)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 1,   1, 1, 1, 438283)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9,   9, 1, 9, 438291)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 5, 1, 1,   1, 1, 1, 11394007)]
        public void RunTwelfthSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(TWELVE_LOOP_INSTRUCTIONS);

            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Input(i8);
            sut.Input(i9);
            sut.Input(i10);
            sut.Input(i11);
            sut.Input(i12);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 1, 1,  1, 1, 16, 42)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1,  1, 0, 0, 1)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5,  5, 0, 0, 9)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 1, 1, 1,  1, 1, 16, 16266)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5,  5, 0, 0, 633)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 6,  6, 1, 21, 16479)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 7,  7, 1, 22, 16480)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 8,  8, 1, 23, 16481)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 9,  9, 1, 24, 16482)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 1, 1, 1,  1, 1, 16, 438090)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 4,  4, 1, 19, 438301)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 5,  5, 0, 0, 16857)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 6,  6, 1, 21, 438303)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 7,  7, 1, 22, 438304)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 8,  8, 1, 23, 438305)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 9,  9, 1, 24, 438306)]
        public void RunThirteenthSectionOfMonadCode(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(THIRTEEN_LOOP_INSTRUCTIONS);
            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Input(i8);
            sut.Input(i9);
            sut.Input(i10);
            sut.Input(i11);
            sut.Input(i12);
            sut.Input(i13);
            sut.Run();
            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }

        [Theory]
        [InlineData(1, 3, 5, 7, 9, 2, 4, 6, 8, 9, 9, 9, 9, 9,   9, 1, 24, 32201934)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 1,   1, 0, 0, 0)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 1,   1, 1, 16, 16)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 2,   2, 1, 17, 17)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 3,   3, 1, 18, 18)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 4,   4, 1, 19, 19)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 5,   5, 1, 20, 20)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 6,   6, 1, 21, 21)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 7,   7, 1, 22, 22)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 8,   8, 1, 23, 23)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 9,   9, 0, 0, 0)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 2,   2, 1, 17, 17)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 3,   3, 1, 18, 18)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 4,   4, 1, 19, 19)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 5,   5, 1, 20, 20)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 6,   6, 1, 21, 21)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 7,   7, 1, 22, 22)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 8,   8, 1, 23, 23)]
        [InlineData(9, 4, 3, 9, 9, 8, 9, 8, 9, 4, 1, 5, 1, 9,   9, 1, 24, 24)]
        [InlineData(9, 9, 3, 9, 8, 9, 9, 4, 9, 4, 9, 8, 5, 9,   9, 1, 24, 437630)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 4, 9,   9, 1, 24, 16482)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 1,   1, 1, 16, 640)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 2,   2, 1, 17, 641)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 3,   3, 1, 18, 642)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 4,   4, 1, 19, 643)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 5,   5, 1, 20, 644)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 6,   6, 1, 21, 645)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 7,   7, 1, 22, 646)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 8,   8, 1, 23, 647)]
        [InlineData(9, 9, 3, 9, 9, 8, 9, 8, 9, 4, 9, 9, 5, 9,   9, 0, 0, 24)]        // 99399 898 949959
        [InlineData(9, 9, 3, 9, 9, 8, 9, 9, 9, 4, 9, 9, 5, 9,   9, 0, 0, 648)]       // 99399 898 949959
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 8, 5, 9,   9, 1, 24, 438306)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 4, 9,   9, 1, 24, 438306)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 5, 1,   1, 1, 16, 16864)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 5, 8,   8, 1, 23, 16871)]
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 5, 9,   9, 0, 0, 648)]       // 99399 994 949959
        [InlineData(9, 9, 3, 9, 9, 9, 9, 4, 9, 4, 9, 9, 6, 1,   1, 1, 16, 438298)]
        public void ValidateSerialNumber(int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8, int i9, int i10, int i11, int i12, int i13, int i14, int expectedW, int expectedX, int expectedY, int expectedZ)
        {
            var sut = new ArithmeticLogicUnit(REAL_INSTRUCTIONS);
            sut.Input(i1);
            sut.Input(i2);
            sut.Input(i3);
            sut.Input(i4);
            sut.Input(i5);
            sut.Input(i6);
            sut.Input(i7);
            sut.Input(i8);
            sut.Input(i9);
            sut.Input(i10);
            sut.Input(i11);
            sut.Input(i12);
            sut.Input(i13);
            sut.Input(i14);
            sut.Run();

            Assert.Equal(expectedW, sut.W);
            Assert.Equal(expectedX, sut.X);
            Assert.Equal(expectedY, sut.Y);
            Assert.Equal(expectedZ, sut.Z);
        }
    }
}