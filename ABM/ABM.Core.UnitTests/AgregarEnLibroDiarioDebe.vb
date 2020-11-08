Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class AgregarEnLibroDiarioDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeAgregaUnaFacturaNula()
        Dim sut As LibroDiario = CreateSystemUnderTest()

        Dim exception As Exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(Nothing))
        Assert.Equal(LibroDiario.INVOICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return LibroDiario.Nuevo.Constructor.Construir()
    End Function
    
    <Fact> Public Sub AceptarDosFacturasIguales_CuandoSeAgregaUnaFacturaSimilar()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim agenda As Agenda = Agenda.Nuevo.Constructor.Construir()

        Dim cliente As Cliente = agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ)
        Dim factura As Factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)
        sut.Agregar(factura)
        factura = sut.Crear(cliente, FECHA_PRIMER_COMPRA)
        sut.Agregar(factura)

        Assert.Equal(2, sut.Total)
    End Sub

    <Fact> Public Sub NoDebeAgregarALaLista_CuandoSeCreaUnaFactura()
        Dim sut As LibroDiario = CreateSystemUnderTest()
        Dim agenda As Agenda = Agenda.Nuevo.Constructor.Construir()

        sut.Crear(agenda.Crear(CLIENTE_JUAN_PEREZ, TELEFONO_DE_JUAN_PEREZ, CORREO_DE_JUAN_PEREZ), FECHA_PRIMER_COMPRA)

        Assert.Equal(0, sut.Total)
    End Sub

End Class