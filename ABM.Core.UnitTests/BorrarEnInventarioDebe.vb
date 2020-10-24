Imports Xunit

Public Class BorrarEnInventarioDebe

    <Fact>
    Public Sub LanzarExcepcion_CuandoSeIntentaBorrarNothing()
        Dim sut As Inventario = CreateSystemUnderTest()
        Dim exception As Exception

        exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(Nothing))
        Assert.Contains(Inventario.PRODUCT_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As Inventario
        Return New Inventario()
    End Function

End Class
