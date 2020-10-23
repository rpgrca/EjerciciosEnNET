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
}