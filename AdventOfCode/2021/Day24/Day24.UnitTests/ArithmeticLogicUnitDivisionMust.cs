using Xunit;
using Day24.Logic;

namespace Day24.UnitTests
{
    public class ArithmeticLogicUnitDivisionMust
    {
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

        [Fact]
        public void ReturnOne_WhenDividingWbyItself()
        {
            var sut = new ArithmeticLogicUnit("inp w\ndiv w w");
            sut.Input(12);
            sut.Run();
            Assert.Equal(1, sut.W);
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

        [Fact]
        public void ReturnOne_WhenDividingXbyItself()
        {
            var sut = new ArithmeticLogicUnit("inp x\ndiv x x");
            sut.Input(12);
            sut.Run();
            Assert.Equal(1, sut.X);
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

        [Fact]
        public void ReturnOne_WhenDividingYbyItself()
        {
            var sut = new ArithmeticLogicUnit("inp y\ndiv y y");
            sut.Input(12);
            sut.Run();
            Assert.Equal(1, sut.Y);
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

        [Fact]
        public void ReturnOne_WhenDividingZbyItself()
        {
            var sut = new ArithmeticLogicUnit("inp z\ndiv z z");
            sut.Input(12);
            sut.Run();
            Assert.Equal(1, sut.Z);
        }
    }
}