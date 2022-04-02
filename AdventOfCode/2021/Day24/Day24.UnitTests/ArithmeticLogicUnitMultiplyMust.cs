using Xunit;
using Day24.Logic;

namespace Day24.UnitTests
{
    public class ArithmeticLogicUnitMultiplyMust
    {
        [Theory]
        [InlineData("inp w\ninp x\nmul w x")]
        [InlineData("inp w\ninp y\nmul w y")]
        [InlineData("inp w\ninp z\nmul w z")]
        [InlineData("inp w\nmul w w")]
        [InlineData("inp w\nmul w 3")]
        public void MultiplyRegisterWcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(3);
            sut.Input(3);
            sut.Run();
            Assert.Equal(9, sut.W);
        }

        [Theory]
        [InlineData("inp x\ninp w\nmul x w")]
        [InlineData("inp x\ninp y\nmul x y")]
        [InlineData("inp x\ninp z\nmul x z")]
        [InlineData("inp x\nmul x x")]
        [InlineData("inp x\nmul x 3")]
        public void MultiplyRegisterXcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(3);
            sut.Input(3);
            sut.Run();
            Assert.Equal(9, sut.X);
        }

        [Theory]
        [InlineData("inp y\ninp w\nmul y w")]
        [InlineData("inp y\ninp x\nmul y x")]
        [InlineData("inp y\ninp z\nmul y z")]
        [InlineData("inp y\nmul y y")]
        [InlineData("inp y\nmul y 3")]
        public void MultiplyRegisterYcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(3);
            sut.Input(3);
            sut.Run();
            Assert.Equal(9, sut.Y);
        }

        [Theory]
        [InlineData("inp z\ninp w\nmul z w")]
        [InlineData("inp z\ninp x\nmul z x")]
        [InlineData("inp z\ninp y\nmul z y")]
        [InlineData("inp z\nmul z z")]
        [InlineData("inp z\nmul z 3")]
        public void MultiplyRegisterZcorrectly(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(3);
            sut.Input(3);
            sut.Run();
            Assert.Equal(9, sut.Z);
        }
    }
}