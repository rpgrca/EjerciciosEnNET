Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class FacturaDebe
    Private Const FECHA_DE_VENTA As Date = #2020/12/13#
    Private Const OTRA_FECHA_DE_VENTA As Date = #2010/12/13#

    <Fact> Public Sub DevolverFacturaConDatos_CuandoSeCreaUnaFacturaAlClienteYEnUnaFecha()
        Dim clientes As New Agenda()
        Dim cliente As Cliente = clientes.Agregar(CLIENTE_JUAN_PEREZ)
        Dim sut As Factura

        sut = New Factura(cliente, FECHA_DE_VENTA)

        Assert.True(sut.HechaA(cliente))
        Assert.True(sut.HechaEl(FECHA_DE_VENTA))
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_AlCrearUnaFacturaSinCliente()
        Dim sut As Factura
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut = New Factura(Nothing, FECHA_DE_VENTA))
        Assert.Equal(Factura.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub LanzarExcepcion_AlCrearUnaFacturaConFechaInvalida()
        Dim clientes As New Agenda()
        Dim cliente As Cliente = clientes.Agregar(CLIENTE_JUAN_PEREZ)
        Dim sut As Factura
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut = New Factura(cliente, Date.MinValue))
        Assert.Equal(Factura.DATE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSePreguntaSiFacturaPerteneceAOtroComprador()
        Dim clientes As New Agenda()
        Dim cliente As Cliente = clientes.Agregar(CLIENTE_JUAN_PEREZ)
        Dim otroCliente As Cliente = clientes.Agregar(CLIENTE_EDUARDO_PEREZ)
        Dim sut As Factura

        sut = New Factura(cliente, FECHA_DE_VENTA)
        Assert.False(sut.HechaA(otroCliente))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSePreguntaSiFacturaEsDeOtraFecha()
        Dim clientes As New Agenda()
        Dim cliente As Cliente = clientes.Agregar(CLIENTE_JUAN_PEREZ)
        Dim sut As Factura

        sut = New Factura(cliente, FECHA_DE_VENTA)
        Assert.False(sut.HechaEl(OTRA_FECHA_DE_VENTA))
    End Sub

    <Fact> Public Sub DevolverTotalCorrecto_CuandoSeAgregaUnDetalle()
        Dim agenda As New Agenda()
        Dim cliente As Cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)
        Dim inventario As New Inventario()
        Dim producto As Producto = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS)
        Dim sut As New Factura(cliente, FECHA_DE_VENTA)

        sut.Agregar(producto, CANTIDAD_COMPRA_LATAS_DE_ARVEJAS)
        Assert.Equal(TOTAL_LATAS_DE_ARVEJAS, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotalCorrecto_CuandoSeAgreganVariosDetalles()
        Dim agenda As New Agenda()
        Dim cliente As Cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)
        Dim inventario As New Inventario()
        Dim producto As Producto = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        Dim otroProducto As Producto = inventario.Agregar(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA)
        Dim sut As New Factura(cliente, FECHA_DE_VENTA)

        sut.Agregar(producto, CANTIDAD_COMPRA_LATAS_DE_ARVEJAS)
        sut.Agregar(otroProducto, CANTIDAD_COMPRA_LATAS_DE_CERVEZA)

        Assert.Equal(TOTAL_LATAS_DE_ARVEJAS_Y_CERVEZA, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeAgregaUnProductoNuloALaFactura()
        Dim agenda As New Agenda()
        Dim cliente As Cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)
        Dim sut As New Factura(cliente, FECHA_DE_VENTA)
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(Nothing, CANTIDAD_COMPRA_LATAS_DE_CERVEZA))
        Assert.Equal(Factura.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData(-1)>
    <InlineData(0)>
    Public Sub LanzarExcepcion_CuandoSeAgregaUnaCantidadInvalidaALaFactura(cantidadInvalida As Integer)
        Dim agenda As New Agenda()
        Dim cliente As Cliente = agenda.Agregar(CLIENTE_JUAN_PEREZ)
        Dim inventario As New Inventario()
        Dim producto As Producto = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        Dim sut As New Factura(cliente, FECHA_DE_VENTA)
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(producto, cantidadInvalida))
        Assert.Equal(Factura.QUANTITY_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class