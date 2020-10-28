Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class CrearEnLibroDiarioDeberia

    <Fact> Public Sub DevolverFacturaCreada_CuandoSeCreaFactura()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim fecha = new Date(2020, 1, 10)
        Dim factura = sut.Crear(cliente, fecha)

        Assert.NotNull(factura)
        Assert.True(factura.HechaA(cliente))
        Assert.True(factura.HechaEl(fecha))
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return new LibroDiario()
    End Function

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaCrearUnaFacturaConClienteNulo()
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(Nothing, #2020/12/13#))
        Assert.Equal(Factura.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeCreaFacturaConFechaNula()
        Dim sut = CreateSystemUnderTest()
        Dim client = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(client, Nothing))
        Assert.Equal(Factura.DATE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeCreaFacturaConFechaMinima()
        Dim sut = CreateSystemUnderTest()
        Dim client = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(client, Date.MinValue))
        Assert.Equal(Factura.DATE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub
    
End Class