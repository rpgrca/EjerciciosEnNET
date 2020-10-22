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

        [Theory]
        [InlineData("neuquen")]
        [InlineData("Neuquen")]
        public void RetornarTrue_CuandoEsUnPalindromo(string palindromo)
        {
            var sut = new Palindromo(palindromo);
            Assert.True(sut.EsUn());
        }
    }
}
