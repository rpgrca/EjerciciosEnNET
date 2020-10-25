﻿Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class ProductoDebe

    <Fact> Public Sub ActualizarElPrecio_CuandoSeCambiaElPrecio()
        Dim inventario = New Inventario()
        Dim producto = inventario.Agregar(LATA_DE_ARVEJAS, PRECIO_UNITARIO_LATA_DE_ARVEJAS, CODIGO_DE_LATA_DE_ARVEJAS)

        producto = producto.CambiarPrecio(PRECIO_UNITARIO_LATA_DE_CERVEZA)

        Assert.False(producto.ConPrecio(PRECIO_UNITARIO_LATA_DE_ARVEJAS))
    End Sub

End Class
