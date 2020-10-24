Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BuscarEnAgendaDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(CLIENTE_JUAN_PEREZ)>
    Public Sub DevolverNothing_CuandoSeBuscaNombreEnAgendaVacia(cualquierNombre As String)
        Dim sut As New Agenda()
        Dim cliente As Object

        cliente = sut.Buscar(cualquierNombre)
        Assert.Null(cliente)
    End Sub

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeBuscaClienteExistente()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        sut.Agregar(CLIENTE_JUAN_PEREZ)

        cliente = sut.Buscar(CLIENTE_JUAN_PEREZ)
        Assert.NotNull(cliente)
        Assert.True(cliente.ConocidoComo(CLIENTE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeBuscaClienteInexistenteEnAgendaConContactos()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        sut.Agregar(CLIENTE_JUAN_PEREZ)

        cliente = sut.Buscar(CLIENTE_EDUARDO_PEREZ)
        Assert.Null(cliente)
    End Sub

    <Fact> Public Sub EncontrarAlCliente_CuandoSeLoRenombraYSeLoModifica()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        cliente = sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        cliente = cliente.CambiarNombre(CLIENTE_EDUARDO_PEREZ)

        sut.Modificar(cliente)
        cliente = sut.Buscar(CLIENTE_EDUARDO_PEREZ)

        Assert.NotNull(cliente)
        Assert.True(cliente.ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(cliente.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(cliente.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

End Class