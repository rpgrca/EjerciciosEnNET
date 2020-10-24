Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BorrarEnAgendaDebe

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeIntentaBorrarNothing()
        Dim sut As New Agenda()
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(Nothing))
        Assert.Contains(Agenda.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class