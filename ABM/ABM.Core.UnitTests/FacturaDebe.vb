Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class FacturaDebe
    Private Const FECHA_VENTA As Date = #2020/12/13#

    <Fact> Public Sub RetornarFacturaConDatos_CuandoSeCreaUnaFacturaAlClienteYEnUnaFecha()
        Dim clientes As New Agenda()
        Dim cliente As Cliente = clientes.Agregar(CLIENTE_JUAN_PEREZ)
        Dim sut As Factura

        sut = New Factura(cliente, FECHA_VENTA)

        Assert.True(sut.HechaA(cliente))
        Assert.True(sut.HechaEl(FECHA_VENTA))
        Assert.Equal(0, sut.Total)
    End Sub

    <Fact> Public Sub LanzarExcepcion_AlCrearUnaFacturaSinCliente()
        Dim sut As Factura
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut = New Factura(Nothing, FECHA_VENTA))
        Assert.Equal(Factura.CLIENT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class