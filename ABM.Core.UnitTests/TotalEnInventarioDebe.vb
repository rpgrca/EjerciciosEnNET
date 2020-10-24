﻿Imports Xunit

Public Class TotalEnInventarioDebe

    Public Const LATA_DE_ARVEJAS As String = "Lata de arvejas Arcor"
    Public Const LATA_DE_CERVEZA As String = "Lata de cerveza Quilmes"

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeProductosDeUnInventarioVacio()
        Dim sut As Inventario

        sut = New Inventario()
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeContactosDeUnaAgendaConUnContacto()
        Dim sut As Inventario

        sut = New Inventario()
        sut.Agregar(LATA_DE_ARVEJAS)

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeInventarioConVariosProductos()
        Dim sut As Inventario

        sut = New Inventario()
        sut.Agregar(LATA_DE_ARVEJAS)
        sut.Agregar(LATA_DE_CERVEZA)

        Assert.Equal(2, sut.Total)
    End Sub

End Class