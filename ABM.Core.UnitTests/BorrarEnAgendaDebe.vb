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

        cliente = sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)

        sut.Borrar(cliente)
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeIntentaBorrarUnClienteQueNoExiste()
        Dim sut As New Agenda()
        Dim cliente As Cliente
        Dim exception As Exception

        cliente = sut.Agregar(CLIENTE_JUAN_PEREZ)
        sut.Borrar(cliente)

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(cliente))
        Assert.Contains(Agenda.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class