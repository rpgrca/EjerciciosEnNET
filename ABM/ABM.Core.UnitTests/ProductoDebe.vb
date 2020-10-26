Imports System.Runtime.Remoting
Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ProductoDebe

    <Fact> Public Sub ActualizarElPrecio_CuandoSeCambiaElPrecio()
        Dim inventario = New Inventario()
        Dim producto = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = producto.CambiarPrecio(PRECIO_UNITARIO_LATA_DE_CERVEZA)

        Assert.False(producto.ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
    End Sub

    <Fact> Public Sub LanzarExcepcion_CuandoSeCambiaElPrecioAUnPrecioInvalido()
        Dim inventario = New Inventario()
        Dim sut = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarPrecio(-1))
        Assert.Equal(Inventario.PRICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    <Theory>
    <InlineData(Nothing)>
    <InlineData("")>
    <InlineData("  ")>
    Public Sub LanzarExcepcion_CuandoSeCambiaElNombreAUnNombreInvalido(nombreInvalido As String)
        Dim inventario = New Inventario()
        Dim sut = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.CambiarNombre(nombreInvalido))
        Assert.Equal(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub


End Class
