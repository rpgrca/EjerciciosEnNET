using System.Collections.Generic;
using Xunit;

namespace SistemaDeAparcamiento.Tests
{
    public class SistemaDeAparcamientoDebe
    {
        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void RetornarFalse_CuandoNoHayAutosEstacionadosEnPlaya(string playa)
        {
            var sut = new Logica.SistemaDeAparcamiento();
            Assert.False(sut.HayAutosEstacionadosEn(playa));
        }

        public static IEnumerable<object[]> ListadoDePlayas()
        {
            yield return new object[] { "izquierda" };
            yield return new object[] { "central" };
            yield return new object[] { "derecha" };
        }

        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void RetornarTrue_CuandoSeEstacionaEnPlayaConLugar(string playa)
        {
            var sut = new Logica.SistemaDeAparcamiento();
            Assert.True(sut.EstacionarEn(playa));
        }

        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void RetornarTrue_CuandoSePreguntaSiHayAutosEstacionadosDespuesDeEstacionar(string playa)
        {
            var sut = new Logica.SistemaDeAparcamiento();
            sut.EstacionarEn(playa);
            Assert.True(sut.HayAutosEstacionadosEn(playa));
        }

        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void RetornarFalse_CuandoSeIntentaEgresarDeUnaPlayaVacia(string playa)
        {
            var sut = new Logica.SistemaDeAparcamiento();
            Assert.False(sut.EgresarDe(playa));
        }

        [Fact]
        public void RetornarFalse_CuandoSePreguntaSiDebeTerminarAlEmpezar()
        {
            var sut = new Logica.SistemaDeAparcamiento();
            Assert.False(sut.DebeTerminar());
        }

        [Theory]
        [MemberData(nameof(ListadoDePlayas))]
        public void RetornarTrue_CuandoSePreguntaSiHayLugarDisponibleEnPlayaVacia(string playa)
        {
            var sut = new Logica.SistemaDeAparcamiento();
            Assert.True(sut.HayEspacioDisponibleEn(playa));
        }
    }
}