Imports Xunit

Public Class CrearEnAgendaDebe

    <Fact> Public Sub DevolverClienteCreado_CuandoSeCreaCliente()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = sut.Crear(Constantes.CLIENTE_JUAN_PEREZ, Constantes.TELEFONO_DE_JUAN_PEREZ, Constantes.CORREO_DE_JUAN_PEREZ)

        Assert.NotNull(cliente)
        Assert.True(cliente.ConocidoComo(Constantes.CLIENTE_JUAN_PEREZ))
        Assert.True(cliente.LlamadoAl(Constantes.TELEFONO_DE_JUAN_PEREZ))
        Assert.True(cliente.MensajeadoAl(Constantes.CORREO_DE_JUAN_PEREZ))
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor().Construir()
    End Function

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaCrearUnClienteConNombreInvalido(nombreInvalido As String)
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(nombreInvalido))
        Assert.Contains(Cliente.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class