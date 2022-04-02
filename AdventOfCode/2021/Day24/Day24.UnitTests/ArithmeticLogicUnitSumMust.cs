using Xunit;
using Day24.Logic;

namespace Day24.UnitTests
{
    public class ArithmeticLogicUnitSumMust
    {
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

        [Fact]
        public void AddWregisterToItselfCorrectly()
        {
            var sut = new ArithmeticLogicUnit("inp w\nadd w w");
            sut.Input(12);
            sut.Run();
            Assert.Equal(24, sut.W);
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

        [Fact]
        public void AddXregisterToItselfCorrectly()
        {
            var sut = new ArithmeticLogicUnit("inp x\nadd x x");
            sut.Input(12);
            sut.Run();
            Assert.Equal(24, sut.X);
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

        [Fact]
        public void AddYregisterToItselfCorrectly()
        {
            var sut = new ArithmeticLogicUnit("inp y\nadd y y");
            sut.Input(12);
            sut.Run();
            Assert.Equal(24, sut.Y);
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

        [Fact]
        public void AddZregisterToItselfCorrectly()
        {
            var sut = new ArithmeticLogicUnit("inp z\nadd z z");
            sut.Input(12);
            sut.Run();
            Assert.Equal(24, sut.Z);
        }
    }
}