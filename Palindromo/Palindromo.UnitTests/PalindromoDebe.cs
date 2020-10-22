using Xunit;

namespace Palindromo.UnitTests
{
    public class PalindromoDebe
    {
        [Fact]
        public void RetornarFalse_CuandoNoEsUnPalindromo()
        {
            var sut = new Palindromo("esto no es un palindromo");
            Assert.False(sut.EsUn());
        }

        [Theory]
        [InlineData("neuquen")]
        [InlineData("Neuquen")]
        [InlineData("43334")]
        public void RetornarTrue_CuandoEsUnPalindromo(string palindromo)
        {
            var sut = new Palindromo(palindromo);
            Assert.True(sut.EsUn());
        }

        [Theory]
        [InlineData("Sometamos o Matemos")]
        [InlineData("Isaac no ronca asi")]
        public void RetornarTrue_CuandoEsUnPalindromoEliminandoEspacios(string palindromoConEspacios)
        {
            var sut = new Palindromo(palindromoConEspacios);
            Assert.True(sut.SinEspaciosEsUn());
        }

        [Theory]
        [InlineData("Sometamos o Matemos")]
        [InlineData("Isaac no ronca asi")]
        public void RetornarFalse_CuandoEsUnPalindromoConEspaciosSinEliminarlos(string palindromoConEspacios)
        {
            var sut = new Palindromo(palindromoConEspacios);
            Assert.False(sut.EsUn());
        }
    }
}