Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class TotalEnAgendaDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeContactosDeUnaAgendaVacia()
        Dim sut As Agenda = CreateSystemUnderTest()

        Assert.Equal(0, sut.Total)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeContactosDeUnaAgendaConUnContacto()
        Dim sut As Agenda = CreateSystemUnderTest()

        sut.Agregar(CLIENTE_JUAN_PEREZ)

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeContactosConVariosContactos()
        Dim sut As Agenda = CreateSystemUnderTest()

        sut.Agregar(CLIENTE_JUAN_PEREZ)
        sut.Agregar(CLIENTE_EDUARDO_PEREZ)

        Assert.Equal(2, sut.Total)
    End Sub

End Class