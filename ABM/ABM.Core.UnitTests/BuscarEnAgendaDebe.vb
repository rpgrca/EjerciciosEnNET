Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BuscarEnAgendaDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(CLIENTE_JUAN_PEREZ)>
    Public Sub DevolverNothing_CuandoSeBuscaNombreEnAgendaVacia(cualquierNombre As String)
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim clientes As List(Of Cliente)

        clientes = sut.Buscar(cualquierNombre)
        Assert.Empty(clientes)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeBuscaClienteExistente()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim clientes As List(Of Cliente)

        sut.Agregar(CLIENTE_JUAN_PEREZ)

        clientes = sut.Buscar(CLIENTE_JUAN_PEREZ)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeBuscaClienteInexistenteEnAgendaConContactos()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim clientes As List(Of Cliente)

        sut.Agregar(CLIENTE_JUAN_PEREZ)

        clientes = sut.Buscar(CLIENTE_EDUARDO_PEREZ)
        Assert.Empty(clientes)
    End Sub

    <Fact> Public Sub EncontrarAlCliente_CuandoSeLoRenombraYSeLoModifica()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente
        Dim clientes As List(Of Cliente)

        cliente = sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.CambiarNombreDe(cliente, CLIENTE_EDUARDO_PEREZ)

        clientes = sut.Buscar(CLIENTE_EDUARDO_PEREZ)

        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(clientes(0).LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(clientes(0).MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub EncontrarAlCliente_CuandoSeRenombraYModificaUnClienteConNombreRepetido()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente
        Dim clientes As List(Of Cliente)

        cliente = sut.Agregar(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.Agregar(CLIENTE_JUAN_PEREZ)
        sut.CambiarNombreDe(cliente, CLIENTE_MARTINA_PEREZ)

        clientes = sut.Buscar(CLIENTE_MARTINA_PEREZ)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_MARTINA_PEREZ))
        Assert.True(clientes(0).LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(clientes(0).MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

End Class