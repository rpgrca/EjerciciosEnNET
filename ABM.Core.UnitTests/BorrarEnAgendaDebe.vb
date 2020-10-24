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

    <Fact>
    Public Sub BorrarCliente_CuandoElClienteExisteEnLaAgenda()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        cliente = sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO, CORREO)
        sut.Borrar(cliente)

        Assert.Equal(0, sut.Total)
    End Sub

End Class