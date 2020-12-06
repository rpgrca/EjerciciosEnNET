using SistemaDeAparcamiento.Logica;
using Xunit;

namespace SistemaDeAparcamiento.Tests
{
    public class PlayaDebe
    {
        [Fact]
        public void EmpezarVacia()
        {
            var sut = new Playa("test", 1);
            Assert.True(sut.TieneEspacioLibre());
            Assert.Equal(0, sut.CantidadDeVehiculosEgresados);
        }

        [Fact]
        public void NoPermitirIngresarMasVehiculosQueLosPermitidos()
        {
            var sut = new Playa("test", 0);
            Assert.False(sut.EstacionarVehiculo());
        }

        [Fact]
        public void PermitirIngresarVehiculos_CuandoHayEspacioDisponible()
        {
            var sut = new Playa("test", 10);
            Assert.True(sut.EstacionarVehiculo());
        }

        [Fact]
        public void NoPermitirIngresarMasVehiculosSiEstaLlena()
        {
            var sut = new Playa("test", 1);
            sut.EstacionarVehiculo();

            Assert.False(sut.EstacionarVehiculo());
        }

        [Fact]
        public void NoPermitirEgreso_CuandoNoHayAutosEstacionados()
        {
            var sut = new Playa("test", 10);

            Assert.False(sut.EgresarVehiculo());
        }

        [Fact]
        public void PermitirEgreso_CuandoHayAutosEstacionados()
        {
            var sut = new Playa("test", 10);
            sut.EstacionarVehiculo();
            Assert.True(sut.EgresarVehiculo());
        }

        [Fact]
        public void NoModificarCantidadDeAutosEgresados_CuandoSeIngresaUnAuto()
        {
            var sut = new Playa("test", 10);

            sut.EstacionarVehiculo();
            Assert.Equal(0, sut.CantidadDeVehiculosEgresados);
        }

        [Fact]
        public void AumentarLaCantidadDeAutosEgresados_CuandoEgresaUnAuto()
        {
            var sut = new Playa("test", 10);
            sut.EstacionarVehiculo();

            sut.EgresarVehiculo();
            Assert.Equal(1, sut.CantidadDeVehiculosEgresados);
        }

        [Fact]
        public void InformarCantidadDeAutosEstacionados()
        {
            var sut = new Playa("test", 10);

            sut.EstacionarVehiculo();
            Assert.Equal(1, sut.CantidadDeVehiculosEstacionados);
        }

        [Fact]
        public void DisminuirCantidadDeAutosEstacionados_CuandoUnVehiculoEgresa()
        {
            var sut = new Playa("test", 10);
            sut.EstacionarVehiculo();
            sut.EgresarVehiculo();
            Assert.Equal(0, sut.CantidadDeVehiculosEstacionados);
        }
    }
}