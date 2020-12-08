using Xunit;

namespace SistemaDeAparcamiento.Logica
{
    public class PlayaDerechaDebe
    {
        [Fact]
        public void InicializarseCorrectamente()
        {
            var sut = new PlayaDerecha();
            Assert.Equal("derecha", sut.Nombre);
            Assert.Equal(0, sut.CantidadDeVehiculosEgresados);
            Assert.Equal(0, sut.CantidadDeVehiculosEstacionados);
        }
    }
}