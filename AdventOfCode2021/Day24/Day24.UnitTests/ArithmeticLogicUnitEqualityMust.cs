using Xunit;
using Day24.Logic;

namespace Day24.UnitTests
{
    public class ArithmeticLogicUnitEqualityMust
    {
        [Theory]
        [InlineData("inp w\ninp x\neql w x")]
        [InlineData("inp w\ninp y\neql w y")]
        [InlineData("inp w\ninp z\neql w z")]
        [InlineData("inp w\neql w w")]
        [InlineData("inp w\neql w 6")]
        public void SetWto1_WhenValuesAreEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(6);
            sut.Run();
            Assert.Equal(1, sut.W);
        }

        [Theory]
        [InlineData("inp w\ninp x\neql w x")]
        [InlineData("inp w\ninp y\neql w y")]
        [InlineData("inp w\ninp z\neql w z")]
        [InlineData("inp w\neql w 5")]
        public void SetWto0_WhenValuesAreNotEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(5);
            sut.Run();
            Assert.Equal(0, sut.W);
        }

        [Theory]
        [InlineData("inp x\ninp w\neql x w")]
        [InlineData("inp x\ninp y\neql x y")]
        [InlineData("inp x\ninp z\neql x z")]
        [InlineData("inp x\neql x x")]
        [InlineData("inp x\neql x 6")]
        public void SetXto1_WhenValuesAreEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(6);
            sut.Run();
            Assert.Equal(1, sut.X);
        }

        [Theory]
        [InlineData("inp x\ninp w\neql x w")]
        [InlineData("inp x\ninp y\neql x y")]
        [InlineData("inp x\ninp z\neql x z")]
        [InlineData("inp x\neql x 5")]
        public void SetXto0_WhenValuesAreNotEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(5);
            sut.Run();
            Assert.Equal(0, sut.X);
        }

        [Theory]
        [InlineData("inp y\ninp w\neql y w")]
        [InlineData("inp y\ninp x\neql y x")]
        [InlineData("inp y\ninp z\neql y z")]
        [InlineData("inp y\neql y y")]
        [InlineData("inp y\neql y 6")]
        public void SetYto1_WhenValuesAreEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(6);
            sut.Run();
            Assert.Equal(1, sut.Y);
        }

        [Theory]
        [InlineData("inp y\ninp w\neql y w")]
        [InlineData("inp y\ninp x\neql y x")]
        [InlineData("inp y\ninp z\neql y z")]
        [InlineData("inp y\neql y 5")]
        public void SetYto0_WhenValuesAreNotEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(5);
            sut.Run();
            Assert.Equal(0, sut.Y);
        }

        [Theory]
        [InlineData("inp z\ninp w\neql z w")]
        [InlineData("inp z\ninp x\neql z x")]
        [InlineData("inp z\ninp y\neql z y")]
        [InlineData("inp z\neql z z")]
        [InlineData("inp z\neql z 6")]
        public void SetZto1_WhenValuesAreEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(6);
            sut.Run();
            Assert.Equal(1, sut.Z);
        }

        [Theory]
        [InlineData("inp z\ninp w\neql z w")]
        [InlineData("inp z\ninp x\neql z x")]
        [InlineData("inp z\ninp y\neql z y")]
        [InlineData("inp z\neql z 5")]
        public void SetZto0_WhenValuesAreNotEqual(string instructions)
        {
            var sut = new ArithmeticLogicUnit(instructions);
            sut.Input(6);
            sut.Input(5);
            sut.Run();
            Assert.Equal(0, sut.Z);
        }
    }
}