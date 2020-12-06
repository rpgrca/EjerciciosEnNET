using Xunit;
using SistemaDeAparcamiento.Logica;

namespace SistemaDeAparcamiento.Tests
{
    public class PlayonDebe
    {
        [Fact]
        public void RetornarCero_CuandoNoHayAutosEstacionados()
        {
            var sut = new Playon();
            sut.Agregar(new Playa("test1", 10));
            sut.Agregar(new Playa("test2", 9));

            Assert.Equal(0, sut.CantidadDeVehiculosEstacionados);
        }

        [Fact]
        public void RetornarCantidadDeAutosEstacionados_CuandoHayAlgunos()
        {
            var sut = new Playon();
            var playa = new Playa("test1", 10);
            playa.EstacionarVehiculo();
            playa.EstacionarVehiculo();
            sut.Agregar(playa);

            playa = new Playa("test2", 5);
            playa.EstacionarVehiculo();
            playa.EstacionarVehiculo();
            playa.EstacionarVehiculo();
            sut.Agregar(playa);

            playa = new Playa("test3", 7);
            playa.EstacionarVehiculo();
            sut.Agregar(playa);

            Assert.Equal(6, sut.CantidadDeVehiculosEstacionados);
        }

        [Fact]
        public void RetornarCero_CuandoNoHayAutosEgresados()
        {
            var sut = new Playon();
            sut.Agregar(new Playa("test1", 10));
            sut.Agregar(new Playa("test2", 5));

            Assert.Equal(0, sut.CantidadDeVehiculosEgresados);
        }

        [Fact]
        public void RetornarCantidadDeVehiculosEgresados_CuandoHayAlgunos()
        {
            var sut = new Playon();
            var playa = new Playa("test1", 10);
            playa.EstacionarVehiculo();
            playa.EgresarVehiculo();
            playa.EstacionarVehiculo();
            sut.Agregar(playa);

            playa = new Playa("test2", 5);
            playa.EstacionarVehiculo();
            playa.EstacionarVehiculo();
            playa.EstacionarVehiculo();
            sut.Agregar(playa);

            playa = new Playa("test3", 7);
            playa.EstacionarVehiculo();
            playa.EgresarVehiculo();
            sut.Agregar(playa);

            Assert.Equal(2, sut.CantidadDeVehiculosEgresados);
        }
    }
}