Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class CrearEnLibroDiarioDeberia

    <Fact> Public Sub DevolverFacturaCreada_CuandoSeCreaFactura()
        Dim sut = CreateSystemUnderTest()
        Dim cliente = Agenda.Nuevo.Constructor.Construir().Crear(CLIENTE_JUAN_PEREZ)
        Dim fecha = new Date(2020, 1, 10)
        Dim factura = sut.Crear(cliente, fecha)

        Assert.NotNull(factura)
        Assert.True(factura.HechaA(cliente))
        Assert.True(factura.HechaEl(fecha))
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return new LibroDiario()
    End Function

End Class

Friend Class LibroDiario
    Public Function Crear(cliente As Cliente, fecha As Date) As Factura
        Return new Factura(cliente, fecha)
    End Function
End Class