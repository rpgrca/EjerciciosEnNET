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
    }

    public class PalindromoDebe
    {
        [Fact]
        public void RetornarFalse_CuandoNoEsUnPalindromo()
        {
            var sut = new Palindromo("esto no es un palindromo");
            Assert.False(sut.EsUn());
        }

        [Fact]
        public void RetornarTrue_CuandoEsUnPalindromo()
        {
            var sut = new Palindromo("neuquen");
            Assert.True(sut.EsUn());
        }

        [Fact]
        public void RetornarTrue_CuandoEsUnPalindromoSinImportarMayusculas()
        {
            var sut = new Palindromo("Neuquen");
            Assert.True(sut.EsUn());
        }
    }
}
