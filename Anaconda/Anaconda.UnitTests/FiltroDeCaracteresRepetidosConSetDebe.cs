using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Anaconda.UnitTests
{
    public class FiltroDeCaracteresRepetidosConSetDebe
    {
        [Theory]
        [InlineData("anaconda", "ancod")]
        [InlineData("murcielago", "murcielago")]
        public void RemoverLetrasRepetidas_CuandoSeFiltra(string palabraOriginal, string palabraFiltrada)
        {
            var sut = new FiltroDeCaracteresRepetidosConSet(palabraOriginal);
            Assert.Equal(palabraFiltrada, sut.Filtrado);
        }
    }

    public class FiltroDeCaracteresRepetidosConSet
    {
        private readonly string _palabraAlimpiar;

        public FiltroDeCaracteresRepetidosConSet(string palabraAlimpiar) => _palabraAlimpiar = palabraAlimpiar;

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

    public class FiltroDeCaracteresRepetidosConLinqDebe
    {
        [Theory]
        [InlineData("anaconda", "ancod")]
        [InlineData("murcielago", "murcielago")]
        public void RemoverLetrasRepetidas_CuandoSeFiltra(string palabraOriginal, string palabraFiltrada)
        {
            var sut = new FiltroDeCaracteresRepetidosConLinq(palabraOriginal);
            Assert.Equal(palabraFiltrada, sut.Filtrado);
        }
    }

    public class FiltroDeCaracteresRepetidosConLinq
    {
        private readonly string _palabraAlimpiar;

        public FiltroDeCaracteresRepetidosConLinq(string palabraAlimpiar) => _palabraAlimpiar = palabraAlimpiar;

        public string Filtrado => new string(_palabraAlimpiar.Distinct().ToArray());
    }
}