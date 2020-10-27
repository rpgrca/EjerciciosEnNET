Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ProductoDebe

    <Fact> Public Sub ActualizarElPrecio_CuandoSeCambiaElPrecio()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = sut.CambiarPrecioDe(producto, PRECIO_UNITARIO_LATA_DE_CERVEZA)

        Assert.False(producto.ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub LanzarExcepcion_CuandoSeCambiaElPrecioAUnPrecioInvalido()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarPrecioDe(producto, -1))
        Assert.Equal(Inventario.PRICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData(Nothing)>
    <InlineData("")>
    <InlineData("  ")>
    Public Sub LanzarExcepcion_CuandoSeCambiaElNombreAUnNombreInvalido(nombreInvalido As String)
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarNombreDe(producto, nombreInvalido))
        Assert.Equal(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosProductosPoseenDistintoId()
        Dim agenda = CreateSystemUnderTest()
        Dim productoJuan = agenda.Crear(CLIENTE_JUAN_PEREZ)
        Dim productoEduardo = agenda.Crear(CLIENTE_EDUARDO_PEREZ)

        Assert.False(productoJuan.Equals(productoEduardo))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoDosProductosPoseenDistintoIdYSeComparaComoObject()
        Dim inventario = CreateSystemUnderTest()
        Dim lataDeArvejas = inventario.Crear(LATA_DE_ARVEJAS)
        Dim lataDeCerveza = inventario.Crear(LATA_DE_CERVEZA)

        Assert.False(lataDeArvejas.Equals(CType(lataDeCerveza, Object)))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosProductosPoseenMismoId()
        Dim lataDeArvejas = CreateSystemUnderTest().Crear(LATA_DE_ARVEJAS)
        Dim lataDeCerveza = CreateSystemUnderTest().Crear(LATA_DE_CERVEZA)

        Assert.True(lataDeArvejas.Equals(lataDeCerveza))
    End Sub

    <Fact> Public Sub DevolverTrue_CuandoDosProductosPoseenMismoIdYSeComparaComoObject()
        Dim lataDeArvejas = CreateSystemUnderTest().Crear(LATA_DE_ARVEJAS)
        Dim lataDeCerveza = CreateSystemUnderTest().Crear(LATA_DE_CERVEZA)

        Assert.True(lataDeArvejas.Equals(CType(lataDeCerveza, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingConProducto()
        Dim inventario = CreateSystemUnderTest()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(Nothing))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaNothingCasteadoAObjetConProducto()
        Dim inventario = CreateSystemUnderTest()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(CType(Nothing, Object)))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaProductoConOtroObjetoCasteadoAProducto()
        Dim inventario = CreateSystemUnderTest()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(New Object()))
    End Sub

    <Fact> Public Sub DevolverFalse_CuandoSeComparaProductoConOtroObjetoCasteadoAObject()
        Dim inventario = CreateSystemUnderTest()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS)

        Assert.False(producto.Equals(inventario))
    End Sub

End Class