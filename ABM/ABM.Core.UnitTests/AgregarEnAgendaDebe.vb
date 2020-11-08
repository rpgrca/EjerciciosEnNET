Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class AgregarEnAgendaDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeAgregaUnClienteNulo()
        Dim sut As Agenda = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(Nothing))
        Assert.Equal(Agenda.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Agenda
        Return Agenda.Nuevo.Constructor().Construir()
    End Function

    <Fact> Public Sub AceptarDosClientesIguales_CuandoSeAgregaUnClienteSimilar()
        Dim sut As Agenda = CreateSystemUnderTest()

        Dim cliente As Cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.Agregar(cliente)
        cliente = sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        sut.Agregar(cliente)

        Assert.Equal(2, sut.Total)
    End Sub

    <Fact> Public Sub NoDebeAgregarALaLista_CuandoSeCreaUnCliente()
        Dim sut As Agenda = CreateSystemUnderTest()

        sut.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)

        Assert.Equal(0, sut.Total)
    End Sub

End Class