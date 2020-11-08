Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BorrarEnLibroDiarioDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaBorrarNothing()
        Dim sut As LibroDiario = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(Nothing))
        Assert.Contains(LibroDiario.INVOICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return LibroDiario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub BorrarFactura_CuandoLaFacturaExisteEnElLibroDiario()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim cliente As Cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim factura As Factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)
        factura = sut.Agregar(factura)

        sut.Borrar(factura)
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaBorrarUnProductoQueNoExiste()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim cliente As Cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim factura As Factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)
        factura = sut.Agregar(factura)
        sut.Borrar(factura)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(factura))
        Assert.Contains(LibroDiario.INVOICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> public Sub LanzarExcepcion_CuandoSeIntentaBorrarUnProductoQueNoFueAgregado()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim cliente As Cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim factura As Factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(factura))
        Assert.Contains(LibroDiario.INVOICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class