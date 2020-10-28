Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BorrarEnAgendaDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaBorrarNothing()
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(Nothing))
        Assert.Contains(Agenda.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub BorrarCliente_CuandoElClienteExisteEnLaAgenda()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        cliente = sut.Agregar(cliente)

        sut.Borrar(cliente)
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaBorrarUnClienteQueNoExiste()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = sut.Crear(CLIENTE_JUAN_PEREZ)
        cliente = sut.Agregar(cliente)
        sut.Borrar(cliente)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(cliente))
        Assert.Contains(Agenda.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub BorrarUnCliente_CuandoSeCambiaLaReferenciaDelClienteABorrar()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ)
        sut.Agregar(cliente)
        sut.Crear(CLIENTE_JUAN_PEREZ)
        cliente = sut.CambiarCorreoDe(cliente, TELEFONO_DE_EDUARDO_PEREZ)

        sut.Borrar(cliente)
        Assert.Equal(1, sut.Total)
    End Sub

End Class