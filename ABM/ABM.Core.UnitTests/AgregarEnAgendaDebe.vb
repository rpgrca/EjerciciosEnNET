Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class AgregarEnAgendaDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnClienteConNombreInvalido(nombreInvalido As String)
        Dim sut As Agenda = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(nombreInvalido))
        Assert.Contains(Cliente.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return New Agenda()
    End Function

    <Fact> Public Sub DevolverClienteAgregado_CuandoSeAgregaCliente()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente

        cliente = sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)

        Assert.NotNull(cliente)
        Assert.True(cliente.ConocidoComo(CLIENTE_JUAN_PEREZ))
        Assert.True(cliente.LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(cliente.MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub AceptarDosClientesIguales_CuandoSeAgregaUnClienteSimilar()
        Dim sut As Agenda = CreateSystemUnderTest()

        sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)

        Assert.Equal(2, sut.Total)
    End Sub

End Class