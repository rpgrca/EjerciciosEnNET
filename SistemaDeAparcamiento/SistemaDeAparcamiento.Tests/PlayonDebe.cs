using System.Collections.Generic;
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

        [Fact]
        public void EmpezarVacia()
        {
            var sut = CrearSubjectUnderTest();

            Assert.False(sut.HayAutosEstacionadosEn("izquierda"));
            Assert.False(sut.HayAutosEstacionadosEn("central"));
            Assert.False(sut.HayAutosEstacionadosEn("derecha"));
            Assert.True(sut.HayEspacioDisponibleEn("izquierda"));
            Assert.True(sut.HayEspacioDisponibleEn("central"));
            Assert.True(sut.HayEspacioDisponibleEn("derecha"));
        }

        private static Playon CrearSubjectUnderTest()
        {
            var sut = new Playon();
            sut.Agregar(new PlayaIzquierda());
            sut.Agregar(new PlayaCentral());
            sut.Agregar(new PlayaDerecha());

            return sut;
        }

        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void EstacionarEnPlaya(string playa)
        {
            var sut = CrearSubjectUnderTest();

            sut.EstacionarEn(playa);
            Assert.True(sut.HayAutosEstacionadosEn(playa));
        }

        public static IEnumerable<object[]> ListadoDePlayas()
        {
            yield return new object[] { "izquierda" };
            yield return new object[] { "central" };
            yield return new object[] { "derecha" };
        }

        [Fact]
        public void ListarLasPlayas()
        {
            var sut = CrearSubjectUnderTest();
            Assert.Collection(sut.ListarPlayas(),
                p1 => Assert.Equal("izquierda", p1),
                p2 => Assert.Equal("central", p2),
                p3 => Assert.Equal("derecha", p3));
        }

        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void RetornarFalse_CuandoNoHayAutosQueEgresarEnUnaPlaya(string playa)
        {
            var sut = CrearSubjectUnderTest();
            Assert.False(sut.EgresarDe(playa));
        }

        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void ObtenerEspacioDisponibleDePlaya(string playa)
        {
            var sut = CrearSubjectUnderTest();
            Assert.True(sut.ObtenerEspacioDisponibleEn(playa) > 0);
        }
    }
}