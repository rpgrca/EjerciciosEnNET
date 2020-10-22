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
            return false;
        }
    }

    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var sut = new Palindromo("esto no es un palindromo");
            Assert.False(sut.EsUn());
        }
    }
}
