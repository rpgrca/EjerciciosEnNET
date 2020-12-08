using Xunit;

namespace SistemaDeAparcamiento.Logica
{
    public class PlayaCentralDebe
    {
        [Fact]
        public void InicializarseCorrectamente()
        {
            var sut = new PlayaCentral();
            Assert.Equal("central", sut.Nombre);
            Assert.Equal(0, sut.CantidadDeVehiculosEgresados);
            Assert.Equal(0, sut.CantidadDeVehiculosEstacionados);
        }
    }
}