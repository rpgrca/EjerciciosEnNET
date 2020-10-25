Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class FacturaDebe

    <Fact> Public Sub RetornarFacturaConDatos_CuandoSeCreaUnaFacturaAlClienteYEnUnaFecha()
        Dim fechaVenta = #2020/12/13#
        Dim clientes As New Agenda()
        Dim cliente As Cliente = clientes.Agregar(CLIENTE_JUAN_PEREZ)
        Dim sut As Factura

        sut = New Factura(cliente, fechaVenta)

        Assert.True(sut.HechaA(cliente))
        Assert.True(sut.HechaEl(fechaVenta))
        Assert.Equal(0, sut.Total)
    End Sub

End Class