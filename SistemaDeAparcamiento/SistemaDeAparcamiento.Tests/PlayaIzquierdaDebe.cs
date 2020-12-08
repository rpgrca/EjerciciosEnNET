using Xunit;
using SistemaDeAparcamiento.Logica;

namespace Tests
{
    public class PlayaIzquierdaDebe
    {
        [Fact]
        public void InicializarseCorrectamente()
        {
            var sut = new PlayaIzquierda();
            Assert.Equal("izquierda", sut.Nombre);
            Assert.Equal(0, sut.CantidadDeVehiculosEgresados);
            Assert.Equal(0, sut.CantidadDeVehiculosEstacionados);
        }

        [Fact]
        public void NoPermitirEgresarVehiculos_SiEsLaPlayaDeLaIzquierda()
        {
            var sut = new PlayaIzquierda();
            sut.EstacionarVehiculo();
            Assert.False(sut.EgresarVehiculo());
        }
    }
}