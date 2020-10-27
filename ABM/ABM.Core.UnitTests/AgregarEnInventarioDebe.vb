Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class CrearEnInventarioDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnProductoConNombreInvalido(nombreInvalido As String)
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(nombreInvalido))
        Assert.Contains(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverClienteCreado_CuandoSeCreaUno()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Assert.NotNull(producto)
        Assert.True(producto.Nombrado(LATA_DE_ARVEJAS))
        Assert.True(producto.ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
        Assert.True(producto.ConCodigo(CODIGO_DE_LATA_DE_ARVEJAS))
    End Sub

    <Fact> Public Sub NoSeAgregaProductoInternamente_CuandoSeCreaUnProducto()
        Dim sut = CreateSystemUnderTest()

        sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Assert.Equal(0, sut.Total)
    End Sub
    
    <Fact> Public Sub CrearProductoConCodigoIgualAUnoExistente_CuandoSeCreaUnoRepetido()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        Dim otroProducto = sut.Crear(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA, CODIGO_DE_LATA_DE_ARVEJAS)

        Assert.True(producto.ConCodigo(CODIGO_DE_LATA_DE_ARVEJAS))
        Assert.True(otroProducto.ConCodigo(CODIGO_DE_LATA_DE_ARVEJAS))

    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaCrearProductoConCodigoYaAgregado()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(producto)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA, CODIGO_DE_LATA_DE_ARVEJAS))
        Assert.Equal(Inventario.CODE_IS_REPEATED_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaCrearProductoConPrecioNegativo()
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(LATA_DE_ARVEJAS, -1, CODIGO_DE_LATA_DE_ARVEJAS))
        Assert.Equal(Inventario.PRICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData("")>
    <InlineData("   ")>
    <InlineData(Nothing)>
    Public Sub LanzarExcepcion_CuandoSeIntentaCrearProductoConCodigoInvalido(codigoInvalido As String)
        Dim sut As Inventario = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, codigoInvalido))
        Assert.Equal(Inventario.CODE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub
    
End Class

Public Class AgregarEnInventarioDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeAgregaProductoNul()
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(Nothing))
        Assert.Equal(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact> Public Sub AceptarDosProductosIguales_CuandoSeAgregaUnProductoConDistintoCodigo()
        Dim sut = CreateSystemUnderTest()

        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(producto)
        producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_CERVEZA)
        sut.Agregar(producto)

        Assert.Equal(2, sut.Total)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function
    
    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaAgregarProductoConCodigoRepetidoQueYaExiste()
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        Dim otroProducto = sut.Crear(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA, CODIGO_DE_LATA_DE_ARVEJAS)

        sut.Agregar(producto)
        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(otroProducto))
        Assert.Equal(Inventario.CODE_IS_REPEATED_EXCEPTION, exception.Message)
    End Sub

End Class