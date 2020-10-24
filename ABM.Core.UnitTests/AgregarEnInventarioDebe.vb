Imports Xunit

Public Class AgregarEnInventarioDebe

    <Theory>
    <InlineData("")>
    <InlineData(Nothing)>
    <InlineData("    ")>
    Public Sub LanzarExcepcion_CuandoSeIntentaAgregarUnProductoConNombreInvalido(nombreInvalido As String)
        Dim sut As New Inventario()
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Agregar(nombreInvalido))
        Assert.Contains(Inventario.NAME_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

End Class
