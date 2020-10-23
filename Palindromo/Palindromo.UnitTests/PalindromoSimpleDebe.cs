using System;
using Xunit;

namespace Palindromo.UnitTests
{
    public class PalindromoSimpleDebe
    {
        [Fact]
        public void RetornarFalse_CuandoNoEsUnPalindromo()
        {
            var sut = new PalindromoSimple("esto no es un palindromo");
            Assert.False(sut.EsUn());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        public void LanzarUnaExcepcion_CuandoLaPalabraAVerificarEsVacioONull(string palabraInvalida)
        {
            var exception = Assert.Throws<ArgumentException>(() => new PalindromoSimple(palabraInvalida));
            Assert.Equal(Palindromo.INVALID_WORD_EXCEPTION, exception.Message);
        }

        [Theory]
        [InlineData("neuquen")]
        [InlineData("Neuquen")]
        [InlineData("43334")]
        public void RetornarTrue_CuandoEsUnPalindromo(string palindromo)
        {
            var sut = new PalindromoSimple(palindromo);
            Assert.True(sut.EsUn());
        }

        [Theory]
        [InlineData("Sometamos o Matemos")]
        [InlineData("Isaac no ronca asi")]
        [InlineData("     Dabale arroz a la zorra el abad")]
        public void RetornarTrue_CuandoEsUnPalindromoEliminandoEspacios(string palindromoConEspacios)
        {
            var sut = new PalindromoSimple(palindromoConEspacios);
            Assert.True(sut.SinEspaciosEsUn());
        }

        [Theory]
        [InlineData("Sometamos o Matemos")]
        [InlineData("Isaac no ronca asi")]
        public void RetornarFalse_CuandoEsUnPalindromoConEspaciosSinEliminarlos(string palindromoConEspacios)
        {
            var sut = new PalindromoSimple(palindromoConEspacios);
            Assert.False(sut.EsUn());
        }
    }
}