Imports Xunit

Public Class AgendaDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeContactosDeUnaAgendaVacia()
        Dim sut As Agenda

        sut = New Agenda()
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeContactosDeUnaAgendaConUnContacto()
        Dim sut As Agenda

        sut = New Agenda()
        sut.Agregar("Juan Perez")

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeContactosConVariosContactos()
        Dim sut As Agenda

        sut = New Agenda()
        sut.Agregar("Juan Perez")
        sut.Agregar("Eduardo Perez")

        Assert.Equal(2, sut.Total)
    End Sub
End Class