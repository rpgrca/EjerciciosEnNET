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

Public Class Agenda

    Private ReadOnly _contactos As List(Of Object)

    Public Sub New()
        _contactos = New List(Of Object)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _contactos.Count
        End Get
    End Property

    Public Sub Agregar(nombre As String)
        _contactos.Add(nombre)
    End Sub

End Class