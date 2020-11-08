Imports Xunit

Public Class CrearEnInventarioDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnProductoConNombreInvalido(nombreInvalido As String)
        Dim sut As Inventario = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(nombreInvalido))
        Assert.Contains(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverClienteCreado_CuandoSeCreaUno()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = sut.Crear(Constantes.LATA_DE_ARVEJAS, Constantes.PRECIO_UNITARIO_LATA_DE_ARVEJAS, Constantes.CODIGO_DE_LATA_DE_ARVEJAS)

        Assert.NotNull(producto)
        Assert.True(producto.Nombrado(Constantes.LATA_DE_ARVEJAS))
        Assert.True(producto.ConPrecio(Constantes.PRECIO_UNITARIO_LATA_DE_ARVEJAS))
        Assert.True(producto.ConCodigo(Constantes.CODIGO_DE_LATA_DE_ARVEJAS))
    End Sub

    <Fact> Public Sub NoSeAgregaProductoInternamente_CuandoSeCreaUnProducto()
        Dim sut As Inventario = CreateSystemUnderTest()

        sut.Crear(Constantes.LATA_DE_ARVEJAS, Constantes.PRECIO_UNITARIO_LATA_DE_ARVEJAS, Constantes.CODIGO_DE_LATA_DE_ARVEJAS)

        Assert.Equal(0, sut.Total)
    End Sub
    
    <Fact> Public Sub CrearProductoConCodigoIgualAUnoExistente_CuandoSeCreaUnoRepetido()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = sut.Crear(Constantes.LATA_DE_ARVEJAS, Constantes.PRECIO_UNITARIO_LATA_DE_ARVEJAS, Constantes.CODIGO_DE_LATA_DE_ARVEJAS)
        Dim otroProducto As Producto = sut.Crear(Constantes.LATA_DE_CERVEZA, Constantes.PRECIO_UNITARIO_LATA_DE_CERVEZA, Constantes.CODIGO_DE_LATA_DE_ARVEJAS)

        Assert.True(producto.ConCodigo(Constantes.CODIGO_DE_LATA_DE_ARVEJAS))
        Assert.True(otroProducto.ConCodigo(Constantes.CODIGO_DE_LATA_DE_ARVEJAS))

    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaCrearProductoConCodigoYaAgregado()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto = sut.Crear(Constantes.LATA_DE_ARVEJAS, Constantes.PRECIO_UNITARIO_LATA_DE_ARVEJAS, Constantes.CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(producto)

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(Constantes.LATA_DE_CERVEZA, Constantes.PRECIO_UNITARIO_LATA_DE_CERVEZA, Constantes.CODIGO_DE_LATA_DE_ARVEJAS))
        Assert.Equal(Inventario.CODE_IS_REPEATED_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaCrearProductoConPrecioNegativo()
        Dim sut As Inventario = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(Constantes.LATA_DE_ARVEJAS, -1, Constantes.CODIGO_DE_LATA_DE_ARVEJAS))
        Assert.Equal(Inventario.PRICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData("")>
    <InlineData("   ")>
    <InlineData(Nothing)>
    Public Sub LanzarExcepcion_CuandoSeIntentaCrearProductoConCodigoInvalido(codigoInvalido As String)
        Dim sut As Inventario = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(Constantes.LATA_DE_ARVEJAS, Constantes.PRECIO_UNITARIO_LATA_DE_ARVEJAS, codigoInvalido))
        Assert.Equal(Inventario.CODE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub
    
End Class