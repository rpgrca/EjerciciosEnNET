Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class CambiarCodigoDeProductoDebe

    <Theory>
    <InlineData(Nothing)>
    <InlineData("")>
    Public Sub LanzarExcepcion_CuandoSeCambiaElCodigoAUnCodigoInvalido(codigoInvalido As String)
        Dim sut = CreateSystemUnderTest()
        Dim producto = sut.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarCodigoDe(producto, codigoInvalido))
        Assert.Equal(Inventario.CODE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeCambiaElCodigoAUnoExistente()
        Dim inventario = CreateSystemUnderTest()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        producto = inventario.Agregar(producto)
        Dim otroProducto = inventario.Crear(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA, CODIGO_DE_LATA_DE_CERVEZA)
        inventario.Agregar(otroProducto)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() inventario.CambiarCodigoDe(producto, CODIGO_DE_LATA_DE_CERVEZA))
        Assert.Equal(Inventario.CODE_IS_REPEATED_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub CambiarCodigoCorrectamente_CuandoSeEligeUnNuevoCodigo()
        Dim inventario = CreateSystemUnderTest()
        Dim producto = inventario.Crear(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = inventario.CambiarCodigoDe(producto, CODIGO_DE_LATA_DE_CERVEZA)
        Assert.True(producto.ConCodigo(CODIGO_DE_LATA_DE_CERVEZA))
    End Sub

End Class
