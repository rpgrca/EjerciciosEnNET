using System;
using Xunit;

namespace Palindromo.UnitTests
{
    public class Palindromo
    {
        private readonly string _aVerificar;

        public Palindromo(string aVerificar)
        {
            this._aVerificar = aVerificar;
        }

        public bool EsUn()
        {
            for (var index = 0; index < _aVerificar.Length / 2; index++)
            {
                if (_aVerificar[index].ToString().ToUpper() != _aVerificar[_aVerificar.Length - 1 - index].ToString().ToUpper())
                {
                    return false;
                }
            }

            return true;
        }

        public bool SinEspaciosEsUn()
        {
            var palabraSinEspacios = _aVerificar.Replace(" ", string.Empty);
            for (var index = 0; index < palabraSinEspacios.Length / 2; index++)
            {
                if (palabraSinEspacios[index].ToString().ToUpper() != palabraSinEspacios[palabraSinEspacios.Length - 1 - index].ToString().ToUpper())
                {
                    return false;
                }
            }

            return true;
        }
    }

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
    }
}
