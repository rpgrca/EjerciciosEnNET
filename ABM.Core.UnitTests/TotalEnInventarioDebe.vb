Imports Xunit

Public Class TotalEnInventarioDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeProductosDeUnInventarioVacio()
        Dim sut As Inventario

        sut = New Inventario()
        Assert.Equal(0, sut.Total)
    End Sub

End Class