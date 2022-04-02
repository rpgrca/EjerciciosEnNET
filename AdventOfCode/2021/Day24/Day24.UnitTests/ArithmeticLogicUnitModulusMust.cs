using Xunit;
using Day24.Logic;

namespace Day24.UnitTests
{
    public class ArithmeticLogicUnitModulusMust
   {
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
        [InlineData("inp w\nmod w w")]
        [InlineData("inp x\nmod x x")]
        [InlineData("inp y\nmod y y")]
        [InlineData("inp z\nmod z z")]
        public void LeaveZeroAsRemainder_WhenSameRegisterIsUsedForMod(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Run();
            Assert.Equal(0, sut.W);
            Assert.Equal(0, sut.X);
            Assert.Equal(0, sut.Y);
            Assert.Equal(0, sut.Z);
        }
    }
}