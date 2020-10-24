Imports Xunit

Public Class BuscarEnAgendaDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(Constantes.CLIENTE_JUAN_PEREZ)>
    Public Sub DevolverNothing_CuandoSeBuscaNombreEnAgendaVacia(cualquierNombre As String)
        Dim sut As New Agenda()
        Dim cliente As Object

        cliente = sut.Buscar(cualquierNombre)
        Assert.Null(cliente)
    End Sub

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeBuscaClienteExistente()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        sut.Agregar(Constantes.CLIENTE_JUAN_PEREZ)

        cliente = sut.Buscar(Constantes.CLIENTE_JUAN_PEREZ)
        Assert.NotNull(cliente)
        Assert.Equal(Constantes.CLIENTE_JUAN_PEREZ, cliente.Nombre)
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeBuscaClienteInexistenteEnAgendaConContactos()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        sut.Agregar(Constantes.CLIENTE_JUAN_PEREZ)

        cliente = sut.Buscar(Constantes.CLIENTE_EDUARDO_PEREZ)
        Assert.Null(cliente)
    End Sub

End Class