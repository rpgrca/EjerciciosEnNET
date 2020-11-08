Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ProductoDebe

    <Fact> Public Sub ActualizarElPrecio_CuandoSeCambiaElPrecio()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = sut.CambiarPrecioDe(producto, PRECIO_UNITARIO_LATA_DE_CERVEZA)

        Assert.False(producto.ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub LanzarExcepcion_CuandoSeCambiaElPrecioAUnPrecioInvalido()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarPrecioDe(producto, -1))
        Assert.Equal(Inventario.PRICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData(Nothing)>
    <InlineData("")>
    <InlineData("  ")>
    Public Sub LanzarExcepcion_CuandoSeCambiaElNombreAUnNombreInvalido(nombreInvalido As String)
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarNombreDe(producto, nombreInvalido))
        Assert.Equal(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub CambiarElNombreCorrectamente()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = sut.CambiarNombreDe(producto, LATA_DE_CERVEZA)
        Assert.True(producto.Nombrado(LATA_DE_CERVEZA))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosProductosPoseenDistintoId()
        Dim inventario As Inventario = CreateSystemUnderTest()
        Dim sut As Producto = inventario.Crear(LATA_DE_ARVEJAS)
        Dim lataDeCerveza As Producto = inventario.Crear(LATA_DE_CERVEZA)

        Assert.False(sut.Equals(lataDeCerveza))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosProductosPoseenDistintoIdYSeComparaComoObject()
        Dim inventario As Inventario = CreateSystemUnderTest()
        Dim sut As Producto = inventario.Crear(LATA_DE_ARVEJAS)
        Dim lataDeCerveza As Producto = inventario.Crear(LATA_DE_CERVEZA)

        Assert.False(sut.Equals(CType(lataDeCerveza, Object)))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosProductosPoseenMismoId()
        Dim sut As Producto = CreateSystemUnderTest().Crear(LATA_DE_ARVEJAS)
        Dim lataDeCerveza As Producto = CreateSystemUnderTest().Crear(LATA_DE_CERVEZA)

        Assert.True(sut.Equals(lataDeCerveza))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosProductosPoseenMismoIdYSeComparaComoObject()
        Dim sut As Producto = CreateSystemUnderTest().Crear(LATA_DE_ARVEJAS)
        Dim lataDeCerveza As Producto = CreateSystemUnderTest().Crear(LATA_DE_CERVEZA)

        Assert.True(sut.Equals(CType(lataDeCerveza, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingConProducto()
        Dim inventario As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(Nothing))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingCasteadoAObjetConProducto()
        Dim inventario As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(CType(Nothing, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaProductoConOtroObjetoCasteadoAProducto()
        Dim inventario As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(New Object()))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaProductoConOtroObjetoCasteadoAObject()
        Dim inventario As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(inventario))
    End Sub

End Class