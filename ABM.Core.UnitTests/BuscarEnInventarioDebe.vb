Imports Xunit
Imports ABM.Core.UnitTests.Constantes

Public Class BuscarEnInventarioDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData(LATA_DE_ARVEJAS)>
    Public Sub DevolverNothing_CuandoSeBuscaNombreEnAgendaVacia(cualquierNombre As String)
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim productos As List(Of Producto)

        productos = sut.Buscar(cualquierNombre)
        Assert.Empty(productos)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return New Inventario()
    End Function

    <Fact> Public Sub DevolverClienteBuscado_CuandoSeBuscaClienteExistente()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim productos As List(Of Producto)

        sut.Agregar(LATA_DE_ARVEJAS)

        productos = sut.Buscar(LATA_DE_ARVEJAS)
        Assert.Single(productos)
        Assert.True(productos(0).Nombrado(LATA_DE_ARVEJAS))
    End Sub

End Class
