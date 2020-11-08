Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class FiltroDeLibroDiarioDebe

    <Fact> Public Sub InicializarseConValoresPorDefectoCorrectos()
        Dim sut As FiltroDeLibroDiario = CreateSystemUnderTest()

        Assert.Null(sut.Cliente)
        Assert.Null(sut.Fecha)
    End Sub

    Private Function CreateSystemUnderTest() As FiltroDeLibroDiario
        Return New FiltroDeLibroDiario
    End Function

    <Fact> Public Sub RecordarElValor_CuandoSeAsignaUnCliente()
        Dim agenda As Agenda = Agenda.Nuevo.Constructor.Construir()
        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim sut As FiltroDeLibroDiario = CreateSystemUnderTest()

        sut.Cliente = cliente

        Assert.Same(cliente, sut.Cliente)
    End Sub

    <Fact> Public Sub RecordarElValor_CuandoSeAsignaUnaFecha()
        Dim fecha As Date = New DateTime(2020, 12, 13, 14, 15, 16)
        Dim sut As FiltroDeLibroDiario = CreateSystemUnderTest()

        sut.Fecha = fecha

        Assert.Equal(fecha, sut.Fecha)
    End Sub

End Class