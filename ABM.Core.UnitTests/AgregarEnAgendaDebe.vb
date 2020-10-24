Imports Xunit

Public Class AgregarEnAgendaDebe
    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnClienteConNombreInvalido(nombreInvalido As String)
        Dim sut As Agenda
        Dim exception As Exception

        sut = New Agenda()

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(nombreInvalido))
        Assert.Contains(Cliente.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub DevolverClienteAgregado_CuandoSeAgregaCliente()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        cliente = sut.Agregar(Constantes.CLIENTE_JUAN_PEREZ, Constantes.TELEFONO, Constantes.CORREO)

        Assert.NotNull(cliente)
        Assert.Equal(Constantes.CLIENTE_JUAN_PEREZ, cliente.Nombre)
        Assert.Equal(Constantes.TELEFONO, cliente.Telefono)
        Assert.Equal(Constantes.CORREO, cliente.Correo)
    End Sub

End Class