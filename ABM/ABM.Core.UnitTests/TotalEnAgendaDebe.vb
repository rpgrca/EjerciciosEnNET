Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class TotalEnAgendaDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeContactosDeUnaAgendaVacia()
        Dim sut = CreateSystemUnderTest()

        Assert.Equal(0, sut.Total)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeContactosDeUnaAgendaConUnContacto()
        Dim sut = CreateSystemUnderTest()

        Dim client = sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.Agregar(client)

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeContactosConVariosContactos()
        Dim sut = CreateSystemUnderTest()

        Dim client = sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.Agregar(client)
        client = sut.Crear(CLIENTE_EDUARDO_PEREZ)
        sut.Agregar(client)

        Assert.Equal(2, sut.Total)
    End Sub

End Class