Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class AgregarEnInventarioDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeAgregaProductoNul()
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(Nothing))
        Assert.Equal(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub AceptarDosProductosIguales_CuandoSeAgregaUnProductoConDistintoCodigo()
        Dim sut = CreateSystemUnderTest()

        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(producto)
        producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_CERVEZA)
        sut.Agregar(producto)

        Assert.Equal(2, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaAgregarProductoConCodigoRepetidoQueYaExiste()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        Dim otroProducto = sut.Crear(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA, CODIGO_DE_LATA_DE_ARVEJAS)

        sut.Agregar(producto)
        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(otroProducto))
        Assert.Equal(Inventario.CODE_IS_REPEATED_EXCEPTION, exception.Message)
    End Sub

End Class