Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class CambiarCodigoDeProductoDebe

    <Theory>
    <InlineData(Nothing)>
    <InlineData("")>
    Public Sub LanzarExcepcion_CuandoSeCambiaElCodigoAUnCodigoInvalido(codigoInvalido As String)
        Dim sut = New Inventario()
        Dim producto = sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarCodigoDe(producto, codigoInvalido))
        Assert.Equal(Inventario.CODE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeCambiaElCodigoAUnoExistente()
        Dim inventario = New Inventario()
        Dim producto = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        inventario.Agregar(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA, CODIGO_DE_LATA_DE_CERVEZA)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() inventario.CambiarCodigoDe(producto, CODIGO_DE_LATA_DE_CERVEZA))
        Assert.Equal(Inventario.CODE_IS_REPEATED_EXCEPTION, exception.Message)
    End Sub

    <Fact>
    Public Sub CambiarCodigoCorrectamente_CuandoSeEligeUnNuevoCodigo()
        Dim inventario = New Inventario()
        Dim producto = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = inventario.CambiarCodigoDe(producto, CODIGO_DE_LATA_DE_CERVEZA)
        Assert.True(producto.ConCodigo(CODIGO_DE_LATA_DE_CERVEZA))
    End Sub

End Class
