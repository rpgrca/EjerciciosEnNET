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

End Class
