using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Anaconda.UnitTests
{
    public class AnacondaDebe
    {
        [Fact]
        public void RemoverLetrasRepetidas_CuandoSeLee()
        {
            var sut = new FiltroDeCaracteresRepetidos("anaconda");
            Assert.Equal("ancod", sut.Filtrado);
        }
    }

    public class FiltroDeCaracteresRepetidos
    {
        private readonly string _palabraAlimpiar;

        public FiltroDeCaracteresRepetidos(string palabraAlimpiar)
        {
            _palabraAlimpiar = palabraAlimpiar;
        }

        public string Filtrado
        {
            get
            {
                var set = new HashSet<char>();

                foreach (var letra in _palabraAlimpiar)
                {
                    set.Add(letra);
                }

                return string.Join(string.Empty, set);
            }
        }
    }
}