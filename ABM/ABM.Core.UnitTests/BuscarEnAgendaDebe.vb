Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class FiltrarEnAgendaDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(CLIENTE_JUAN_PEREZ)>
    Public Sub DevolverNothing_CuandoSeFiltraNombreEnAgendaVacia(cualquierNombre As String)
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim filtro As FiltroDeAgenda = New FiltroDeAgenda With {
            .Nombre = cualquierNombre
        }

        Dim clientes As List(Of Cliente) = sut.Filtrar(filtro)
        Assert.Empty(clientes)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeFiltraClienteAgregado()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.Agregar(cliente)

        Dim filtro As FiltroDeAgenda = New FiltroDeAgenda()
        filtro.Nombre = CLIENTE_JUAN_PEREZ

        Dim clientes As List(Of Cliente) = sut.Filtrar(filtro)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeFiltraClienteInexistenteEnAgendaConContactos()
        Dim sut As Agenda = CreateSystemUnderTest()
        sut.Crear(CLIENTE_JUAN_PEREZ)

        Dim filtro As FiltroDeAgenda = New FiltroDeAgenda With {
            .Nombre = CLIENTE_EDUARDO_PEREZ
        }

        Dim clientes As List(Of Cliente) = sut.Filtrar(filtro)
        Assert.Empty(clientes)
    End Sub

    <Fact> Public Sub EncontrarAlCliente_CuandoSeLoRenombraYSeLoModifica()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.CambiarNombreDe(cliente, CLIENTE_EDUARDO_PEREZ)

        Dim filtro As FiltroDeAgenda = New FiltroDeAgenda With {
            .Nombre = CLIENTE_EDUARDO_PEREZ
        }

        Dim clientes As List(Of Cliente) = sut.Filtrar(filtro)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_EDUARDO_PEREZ))
        Assert.True(clientes(0).LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(clientes(0).MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub EncontrarAlCliente_CuandoSeRenombraYModificaUnClienteConNombreRepetido()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.CambiarNombreDe(cliente, CLIENTE_MARTINA_PEREZ)

        Dim filtro As FiltroDeAgenda = New FiltroDeAgenda With {
            .Nombre = CLIENTE_MARTINA_PEREZ
        }
        
        Dim clientes As List(Of Cliente) = sut.Filtrar(filtro)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_MARTINA_PEREZ))
        Assert.True(clientes(0).LlamadoAl(TELEFONO_DE_JUAN_PEREZ))
        Assert.True(clientes(0).MensajeadoAl(CORREO_DE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeFiltraPorId()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.Agregar(cliente)

        Dim filtro As FiltroDeAgenda = New FiltroDeAgenda With { .Id = 1 }

        Dim clientes As List(Of Cliente) = sut.Filtrar(filtro)
        Assert.Single(clientes)
        Assert.True(clientes(0).ConocidoComo(CLIENTE_JUAN_PEREZ))
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeFiltraClienteInexistentePorId()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = sut.Crear(CLIENTE_JUAN_PEREZ)
        sut.Agregar(cliente)

        Dim filtro As FiltroDeAgenda = New FiltroDeAgenda With { .Id = 100 }

        Dim clientes As List(Of Cliente) = sut.Filtrar(filtro)
        Assert.Empty(clientes)
    End Sub

    <Fact> Public Sub DevolverTodos_CuandoSeFiltraSinFiltro()
        Dim sut As Agenda = CreateSystemUnderTest()
        Dim cliente As Cliente = sut.Agregar(sut.Crear(CLIENTE_JUAN_PEREZ))
        Dim otroCliente As Cliente = sut.Agregar(sut.Crear(CLIENTE_EDUARDO_PEREZ))

        Dim clientes As List(Of Cliente) = sut.Filtrar(Nothing)
        Assert.Collection(clientes, _
                          Sub(c1) Assert.True(c1.Equals(cliente)),
                          Sub(c2) Assert.True(c2.Equals(otroCliente)))
    End Sub

End Class