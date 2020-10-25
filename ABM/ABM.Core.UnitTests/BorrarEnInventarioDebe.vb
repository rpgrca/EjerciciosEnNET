Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BorrarEnInventarioDebe

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeIntentaBorrarNothing()
        Dim sut As Inventario = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(Nothing))
        Assert.Contains(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return New Inventario()
    End Function

    <Fact>
    Public Sub BorrarProducto_CuandoElProductoExisteEnLaAgenda()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto

        producto = sut.Agregar(LATA_DE_ARVEJAS)

        sut.Borrar(producto)
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeIntentaBorrarUnProductoQueNoExiste()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto

        producto = sut.Agregar(LATA_DE_ARVEJAS)
        sut.Borrar(producto)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(producto))
        Assert.Contains(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub BorrarUnCliente_CuandoSeCambiaLaReferenciaDelClienteABorrar()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto

        producto = sut.Agregar(LATA_DE_ARVEJAS, , CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(LATA_DE_ARVEJAS, , CODIGO_DE_LATA_DE_CERVEZA)
        producto = producto.CambiarPrecio(PRECIO_UNITARIO_LATA_DE_CERVEZA)

        sut.Borrar(producto)
        Assert.Equal(1, sut.Total)
    End Sub

End Class
