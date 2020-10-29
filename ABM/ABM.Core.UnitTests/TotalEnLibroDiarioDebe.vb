Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class TotalEnLibroDiarioDebe

    <Fact> Public Sub DevolverCero_CuandoSePideElTotalDeFacturasDeUnLibroDiarioVacio()
        Dim sut = CreateSystemUnderTest()

        Assert.Equal(0, sut.Total)
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return LibroDiario.Nuevo.Constructor.Construir()
    End Function

    <Fact> Public Sub DevolverUno_CuandoSePideElTotalDeFacturasDeUnLibroDiarioConUnaFactura()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)

        Dim factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)
        sut.Agregar(factura)

        Assert.Equal(1, sut.Total)
    End Sub

    <Fact> Public Sub DevolverTotal_CuandoSePideElTotalDeFacturasConVariasFacturas()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)

        Dim factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)
        sut.Agregar(factura)

        factura = sut.Crear(cliente, FECHA_SEGUNDA_COMPRA)
        sut.Agregar(factura)

        Assert.Equal(2, sut.Total)
    End Sub

End Class