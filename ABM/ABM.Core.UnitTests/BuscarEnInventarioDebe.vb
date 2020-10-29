'Imports Xunit
'Imports ABM.Core.UnitTests.Constantes

'Public Class BuscarEnInventarioDebe

'    <Theory>
'    <InlineData("")>
'    <InlineData(Nothing)>
'    <InlineData(LATA_DE_ARVEJAS)>
'    Public Sub DevolverNothing_CuandoSeBuscaNombreEnInventarioVacio(cualquierNombre As String)
'        Dim sut = CreateSystemUnderTest()

'        Dim productos = sut.Buscar(cualquierNombre)
'        Assert.Empty(productos)
'    End Sub

'    Private Function CreateSystemUnderTest() As Inventario
'        Return Inventario.Nuevo.Constructor.Construir()
'    End Function

'    <Fact> Public Sub DevolverProductoBuscado_CuandoSeBuscaInventarioExistente()
'        Dim sut = CreateSystemUnderTest()
'        Dim producto = sut.Crear(LATA_DE_ARVEJAS)
'        sut.Agregar(producto)

'        Dim productos = sut.Buscar(LATA_DE_ARVEJAS)
'        Assert.Single(productos)
'        Assert.True(productos(0).Nombrado(LATA_DE_ARVEJAS))
'    End Sub

'    <Fact> Public Sub DevolverNothing_CuandoSeBuscaProductoInexistenteEnIventarioConProductos()
'        Dim sut = CreateSystemUnderTest()
'        sut.Crear(LATA_DE_ARVEJAS)

'        Dim productos = sut.Buscar(LATA_DE_CERVEZA)
'        Assert.Empty(productos)
'    End Sub

'    <Fact> Public Sub EncontrarAlProducto_CuandoSeLoRenombraYSeLoModifica()
'        Dim sut = CreateSystemUnderTest()
'        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
'        sut.CambiarNombreDe(producto, LATA_DE_CERVEZA)

'        Dim productos = sut.Buscar(LATA_DE_CERVEZA)
'        Assert.Single(productos)
'        Assert.True(productos(0).Nombrado(LATA_DE_CERVEZA))
'        Assert.True(productos(0).ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
'        Assert.True(productos(0).ConCodigo(CODIGO_DE_LATA_DE_ARVEJAS))
'    End Sub

'    <Fact> Public Sub EncontrarAlProducto_CuandoSeRenombraYModificaUnProductoConNombreRepetido()
'        Dim sut = CreateSystemUnderTest()
'        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS)
'        sut.Crear(LATA_DE_ARVEJAS)
'        sut.CambiarNombreDe(producto, LATA_DE_CERVEZA)

'        Dim productos = sut.Buscar(LATA_DE_CERVEZA)
'        Assert.Single(productos)
'        Assert.True(productos(0).Nombrado(LATA_DE_CERVEZA))
'        Assert.True(productos(0).ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
'        Assert.True(productos(0).ConCodigo(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
'    End Sub

'End Class
