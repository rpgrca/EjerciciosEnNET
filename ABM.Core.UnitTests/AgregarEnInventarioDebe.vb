Imports Xunit

Public Class AgregarEnInventarioDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnProductoConNombreInvalido(nombreInvalido As String)
        Dim sut As Inventario = GetSystemUnderTest()
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(nombreInvalido))
        Assert.Contains(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function GetSystemUnderTest() As Inventario
        Return New Inventario()
    End Function

End Class
