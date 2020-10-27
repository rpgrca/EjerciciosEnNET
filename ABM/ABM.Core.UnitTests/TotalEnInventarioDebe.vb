Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class TotalEnInventarioDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeProductosDeUnInventarioVacio()
        Dim sut = CreateSystemUnderTest()

        Assert.Equal(0, sut.Total)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return Inventario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeContactosDeUnaAgendaConUnContacto()
        Dim sut = CreateSystemUnderTest()

        Dim product = sut.Crear(LATA_DE_ARVEJAS)
        sut.Agregar(product)

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeInventarioConVariosProductos()
        Dim sut = CreateSystemUnderTest()

        Dim product = sut.Crear(LATA_DE_ARVEJAS, , CODIGO_DE_LATA_DE_ARVEJAS)
        sut.Agregar(product)

        product = sut.Crear(LATA_DE_CERVEZA, , CODIGO_DE_LATA_DE_CERVEZA)
        sut.Agregar(product)

        Assert.Equal(2, sut.Total)
    End Sub

End Class