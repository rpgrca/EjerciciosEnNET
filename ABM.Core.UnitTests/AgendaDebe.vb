Imports Xunit

Public Class AgendaDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeContactosDeUnaAgendaVacia()
        Dim sut As Agenda

        sut = New Agenda()
        Assert.Equal(0, sut.Total)
    End Sub

End Class

Public Class Agenda

    Public ReadOnly Property Total As Integer
        Get
            Return 0
        End Get
    End Property

End Class