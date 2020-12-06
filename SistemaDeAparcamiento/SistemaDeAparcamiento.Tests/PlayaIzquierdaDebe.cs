using Xunit;
using SistemaDeAparcamiento.Logica;

namespace Tests
{
    public class PlayaIzquierdaDebe
    {
        [Fact]
        public void NoPermitirEgresarVehiculos_SiEsLaPlayaDeLaIzquierda()
        {
            var sut = new PlayaIzquierda();
            sut.EstacionarVehiculo();
            Assert.False(sut.EgresarVehiculo());
        }
    }
}