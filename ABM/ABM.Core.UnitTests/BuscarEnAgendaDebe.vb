Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BuscarEnAgendaDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(CLIENTE_JUAN_PEREZ)>
    Public Sub DevolverNothing_CuandoSeBuscaNombreEnAgendaVacia(cualquierNombre As String)
        Dim sut = CreateSystemUnderTest()

        Dim clientes = sut.Buscar(cualquierNombre)
        Assert.Empty(clientes)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeBuscaClienteAgregado()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.Agregar(cliente)

        Dim clientes = sut.Buscar(CLIENTE_JUAN_PEREZ)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeBuscaClienteInexistenteEnAgendaConContactos()
        Dim sut = CreateSystemUnderTest()
        sut.Crear(CLIENTE_JUAN_PEREZ)

        Dim clientes = sut.Buscar(CLIENTE_EDUARDO_PEREZ)
        Assert.Empty(clientes)
    End Sub

    <Fact> Public Sub EncontrarAlCliente_CuandoSeLoRenombraYSeLoModifica()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.CambiarNombreDe(cliente, CLIENTE_EDUARDO_PEREZ)

        Dim clientes = sut.Buscar(CLIENTE_EDUARDO_PEREZ)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(clientes(0).LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(clientes(0).MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub EncontrarAlCliente_CuandoSeRenombraYModificaUnClienteConNombreRepetido()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.CambiarNombreDe(cliente, CLIENTE_MARTINA_PEREZ)

        Dim clientes = sut.Buscar(CLIENTE_MARTINA_PEREZ)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_MARTINA_PEREZ))
        Assert.True(clientes(0).LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(clientes(0).MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

End Class