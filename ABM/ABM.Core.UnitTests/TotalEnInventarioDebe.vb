﻿Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class TotalEnInventarioDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeProductosDeUnInventarioVacio()
        Dim sut As Inventario = CreateSystemUnderTest()

        Assert.Equal(0, sut.Total)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeContactosDeUnaAgendaConUnContacto()
        Dim sut As Inventario = CreateSystemUnderTest()

        Dim producto As Producto = sut.Crear(LATA_DE_ARVEJAS)
        sut.Agregar(producto)

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeInventarioConVariosProductos()
        Dim sut As Inventario = CreateSystemUnderTest()

        Dim producto As Producto = sut.Crear(LATA_DE_ARVEJAS, , CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(producto)

        producto = sut.Crear(LATA_DE_CERVEZA, , CODIGO_DE_LATA_DE_CERVEZA)
        sut.Agregar(producto)

        Assert.Equal(2, sut.Total)
    End Sub

End Class