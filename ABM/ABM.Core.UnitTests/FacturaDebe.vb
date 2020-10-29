Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class FacturaDebe
    Private Const FECHA_DE_VENTA As Date = #2020/12/13#
    Private Const OTRA_FECHA_DE_VENTA As Date = #2010/12/13#

    <Fact> Public Sub DevolverFacturaConDatos_CuandoSeCreaUnaFacturaAlClienteYEnUnaFecha()
        Dim libroDiario = CreateSystemUnderTest()
        Dim cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim sut = libroDiario.Crear(cliente, FECHA_DE_VENTA)

        Assert.True(sut.HechaA(cliente))
        Assert.True(sut.HechaEl(FECHA_DE_VENTA))
        Assert.Equal(0, sut.Total)
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return LibroDiario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub LanzarExcepcion_AlCrearUnaFacturaSinCliente()
        Dim libroDiario = CreateSystemUnderTest()
        Dim sut As Factura

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut = libroDiario.Crear(Nothing, FECHA_DE_VENTA))
        Assert.Equal(Factura.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub LanzarExcepcion_AlCrearUnaFacturaConFechaInvalida()
        Dim libroDiario = CreateSystemUnderTest()
        Dim cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim sut As Factura

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut = libroDiario.Crear(cliente, Date.MinValue))
        Assert.Equal(Factura.DATE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSePreguntaSiFacturaPerteneceAOtroComprador()
        Dim agenda = Core.Agenda.Nuevo.Constructor.Construir()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim otroCliente = agenda.Crear(CLIENTE_EDUARDO_PEREZ)

        Dim sut = CreateSystemUnderTest().Crear(cliente, FECHA_DE_VENTA)
        Assert.False(sut.HechaA(otroCliente))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSePreguntaSiFacturaEsDeOtraFecha()
        Dim agenda = Core.Agenda.Nuevo.Constructor.Construir()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)

        Dim sut = CreateSystemUnderTest().Crear(cliente, FECHA_DE_VENTA)
        Assert.False(sut.HechaEl(OTRA_FECHA_DE_VENTA))
    End Sub

    <Fact> Public Sub DevolverTotalCorrecto_CuandoSeAgregaUnDetalle()
        Dim agenda = Core.Agenda.Nuevo.Constructor.Construir()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim inventario As Inventario = Inventario.Nuevo.Constructor.Construir()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS)
        Dim sut = CreateSystemUnderTest().Crear(cliente, FECHA_DE_VENTA)

        sut.Agregar(producto, CANTIDAD_COMPRA_LATAS_DE_ARVEJAS)
        Assert.Equal(TOTAL_LATAS_DE_ARVEJAS, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotalCorrecto_CuandoSeAgreganVariosDetalles()
        Dim agenda = Core.Agenda.Nuevo.Constructor.Construir()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim inventario As Inventario = Inventario.Nuevo.Constructor.Construir()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        Dim otroProducto = inventario.Crear(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA)
        Dim sut = CreateSystemUnderTest().Crear(cliente, FECHA_DE_VENTA)

        sut.Agregar(producto, CANTIDAD_COMPRA_LATAS_DE_ARVEJAS)
        sut.Agregar(otroProducto, CANTIDAD_COMPRA_LATAS_DE_CERVEZA)

        Assert.Equal(TOTAL_LATAS_DE_ARVEJAS_Y_CERVEZA, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeAgregaUnProductoNuloALaFactura()
        Dim agenda = Core.Agenda.Nuevo.Constructor.Construir()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim sut = CreateSystemUnderTest().Crear(cliente, FECHA_DE_VENTA)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(Nothing, CANTIDAD_COMPRA_LATAS_DE_CERVEZA))
        Assert.Equal(Factura.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData(-1)>
    <InlineData(0)>
    Public Sub LanzarExcepcion_CuandoSeAgregaUnaCantidadInvalidaALaFactura(cantidadInvalida As Integer)
        Dim agenda = Core.Agenda.Nuevo.Constructor.Construir()
        Dim cliente = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim inventario As Inventario = Inventario.Nuevo.Constructor.Construir()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        Dim sut = CreateSystemUnderTest().Crear(cliente, FECHA_DE_VENTA)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(producto, cantidadInvalida))
        Assert.Equal(Factura.QUANTITY_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub CambiarLaFechaCorrectamente()
        Dim cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim sut = CreateSystemUnderTest()
        Dim factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)

        factura = sut.CambiarFechaDe(factura, FECHA_SEGUNDA_COMPRA)
        Assert.True(factura.HechaEl(FECHA_SEGUNDA_COMPRA))
    End Sub

End Class