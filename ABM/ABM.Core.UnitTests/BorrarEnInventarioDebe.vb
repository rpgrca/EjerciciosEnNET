Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BorrarEnInventarioDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaBorrarNothing()
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(Nothing))
        Assert.Contains(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub BorrarProducto_CuandoElProductoExisteEnLaAgenda()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS)
        producto = sut.Agregar(producto)

        sut.Borrar(producto)
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaBorrarUnProductoQueNoExiste()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS)
        producto = sut.Agregar(producto)
        sut.Borrar(producto)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(producto))
        Assert.Contains(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> public Sub LanzarExcepcion_CuandoSeIntentaBorrarUnProductoQueNoFueAgregado()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(producto))
        Assert.Contains(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub BorrarUnProducto_CuandoSeCambiaLaReferenciaDelProductoABorrar()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, , CODIGO_DE_LATA_DE_ARVEJAS)
        producto = sut.Agregar(producto)
        Dim otroProducto = sut.Crear(LATA_DE_ARVEJAS, , CODIGO_DE_LATA_DE_CERVEZA)
        sut.Agregar(otroProducto)

        producto = sut.CambiarPrecioDe(producto, PRECIO_UNITARIO_LATA_DE_CERVEZA)

        sut.Borrar(producto)
        Assert.Equal(1, sut.Total)
    End Sub

End Class
