Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class CrearEnLibroDiarioDeberia

    <Fact> Public Sub DevolverFacturaCreada_CuandoSeCreaFactura()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim cliente As Cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim fecha As Date = new Date(2020, 1, 10)
        Dim factura As Factura = sut.Crear(cliente, fecha)

        Assert.NotNull(factura)
        Assert.True(factura.HechaA(cliente))
        Assert.True(factura.HechaEl(fecha))
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return LibroDiario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaCrearUnaFacturaConClienteNulo()
        Dim sut As LibroDiario = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(Nothing, #2020/12/13#))
        Assert.Equal(Factura.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeCreaFacturaConFechaNula()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim cliente As Cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(cliente, Nothing))
        Assert.Equal(Factura.DATE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeCreaFacturaConFechaMinima()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim cliente As Cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(cliente, Date.MinValue))
        Assert.Equal(Factura.DATE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub
    
End Class