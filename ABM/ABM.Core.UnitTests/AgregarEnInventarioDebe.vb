Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class AgregarEnInventarioDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnProductoConNombreInvalido(nombreInvalido As String)
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(nombreInvalido))
        Assert.Contains(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return New Inventario()
    End Function

    <Fact> Public Sub DevolverClienteAgregado_CuandoSeAgregaCliente()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim producto As Producto

        producto = sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Assert.NotNull(producto)
        Assert.True(producto.Nombrado(LATA_DE_ARVEJAS))
        Assert.True(producto.ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
        Assert.True(producto.ConCodigo(CODIGO_DE_LATA_DE_ARVEJAS))
    End Sub

    <Fact> Public Sub AceptarDosProductosIguales_CuandoSeAgregaUnProductoConDistintoCodigo()
        Dim sut As Inventario = CreateSystemUnderTest()

        sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_CERVEZA)

        Assert.Equal(2, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaAgregarProductoConCodigoRepetido()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim exception As Exception

        sut.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)
        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(LATA_DE_CERVEZA, PRECIO_UNITARIO_LATA_DE_CERVEZA, CODIGO_DE_LATA_DE_ARVEJAS))
        Assert.Equal(Inventario.CODE_IS_REPEATED_EXCEPTION, exception.Message)
    End Sub

End Class