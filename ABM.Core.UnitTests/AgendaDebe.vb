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

End Class

Public Class Agenda

    Private _agregado As Boolean

    Public ReadOnly Property Total As Integer
        Get
            If _agregado Then
                Return 1
            End If

            Return 0
        End Get
    End Property

    Public Sub Agregar(nombre As String)
        _agregado = True
    End Sub

End Class