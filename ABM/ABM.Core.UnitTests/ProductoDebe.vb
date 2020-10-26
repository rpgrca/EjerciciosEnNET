Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ProductoDebe

    <Fact> Public Sub ActualizarElPrecio_CuandoSeCambiaElPrecio()
        Dim sut = New Inventario()
        Dim producto = sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = sut.CambiarPrecioDe(producto, PRECIO_UNITARIO_LATA_DE_CERVEZA)

        Assert.False(producto.ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeCambiaElPrecioAUnPrecioInvalido()
        Dim sut = New Inventario()
        Dim producto = sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarPrecioDe(producto, -1))
        Assert.Equal(Inventario.PRICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData(Nothing)>
    <InlineData("")>
    <InlineData("  ")>
    Public Sub LanzarExcepcion_CuandoSeCambiaElNombreAUnNombreInvalido(nombreInvalido As String)
        Dim sut = New Inventario()
        Dim producto = sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarNombreDe(producto, nombreInvalido))
        Assert.Equal(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class
