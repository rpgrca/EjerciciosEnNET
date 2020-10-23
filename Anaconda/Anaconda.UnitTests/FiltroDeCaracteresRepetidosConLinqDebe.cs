using Xunit;

namespace Anaconda.UnitTests
{

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
}