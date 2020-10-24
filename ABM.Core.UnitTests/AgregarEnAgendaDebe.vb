Imports Xunit

Public Class AgregarEnAgendaDebe
    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnClienteConNombreInvalido(nombreInvalido As String)
        Dim sut As New Agenda()
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(nombreInvalido))
        Assert.Contains(Cliente.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub DevolverClienteAgregado_CuandoSeAgregaCliente()
        Dim sut As New Agenda()
        Dim cliente As Cliente

        cliente = sut.Agregar(Constantes.CLIENTE_JUAN_PEREZ, Constantes.TELEFONO_DE_JUAN_PEREZ, Constantes.CORREO_DE_JUAN_PEREZ)

        Assert.NotNull(cliente)
        Assert.True(cliente.ConocidoComo(Constantes.CLIENTE_JUAN_PEREZ))
        Assert.True(cliente.LlamadoAl(Constantes.TELEFONO_DE_JUAN_PEREZ))
        Assert.True(cliente.MensajeadoAl(Constantes.CORREO_DE_JUAN_PEREZ))
    End Sub

End Class