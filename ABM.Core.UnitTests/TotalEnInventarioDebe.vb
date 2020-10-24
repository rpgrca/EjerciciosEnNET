Imports Xunit

Public Class TotalEnInventarioDebe

    Public Const LATA_DE_ARVEJAS As String = "Lata de arvejas Arcor"

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

End Class