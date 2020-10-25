Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BuscarEnInventarioDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(LATA_DE_ARVEJAS)>
    Public Sub DevolverNothing_CuandoSeBuscaNombreEnInventarioVacio(cualquierNombre As String)
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim productos As List(Of Producto)

        productos = sut.Buscar(cualquierNombre)
        Assert.Empty(productos)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return New Inventario()
    End Function

    <Fact> Public Sub DevolverProductoBuscado_CuandoSeBuscaInventarioExistente()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim productos As List(Of Producto)

        sut.Agregar(LATA_DE_ARVEJAS)

        productos = sut.Buscar(LATA_DE_ARVEJAS)
        Assert.Single(productos)
        Assert.True(productos(0).Nombrado(LATA_DE_ARVEJAS))
    End Sub

    <Fact> Public Sub DevolverNothing_CuandoSeBuscaProductoInexistenteEnIventarioConProductos()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim productos As List(Of Producto)

        sut.Agregar(LATA_DE_ARVEJAS)

        productos = sut.Buscar(LATA_DE_CERVEZA)
        Assert.Empty(productos)
    End Sub

    <Fact> Public Sub EncontrarAlProducto_CuandoSeLoRenombraYSeLoModifica()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto
        Dim productos As List(Of Producto)

        producto = sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        producto = producto.CambiarNombre(LATA_DE_CERVEZA)
        sut.Modificar(producto)

        productos = sut.Buscar(LATA_DE_CERVEZA)

        Assert.Single(productos)
        Assert.True(productos(0).Nombrado(LATA_DE_CERVEZA))
        Assert.True(productos(0).ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
        Assert.True(productos(0).ConCodigo(CODIGO_DE_LATA_DE_ARVEJAS))
    End Sub

    <Fact> Public Sub EncontrarAlProducto_CuandoSeRenombraYModificaUnProductoConNombreRepetido()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto
        Dim productos As List(Of Producto)

        producto = sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS)
        sut.Agregar(LATA_DE_ARVEJAS)
        producto = producto.CambiarNombre(LATA_DE_CERVEZA)

        sut.Modificar(producto)
        productos = sut.Buscar(LATA_DE_CERVEZA)

        Assert.Single(productos)
        Assert.True(productos(0).Nombrado(LATA_DE_CERVEZA))
        Assert.True(productos(0).ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
        Assert.True(productos(0).ConCodigo(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
    End Sub

End Class
