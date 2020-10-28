Imports Xunit

Public Class BorrarEnLibroDiarioDebe

    <Fact> Public Sub LanzarExcepcion_CuandoSeIntentaBorrarNothing()
        Dim sut = CreateSystemUnderTest()

        Dim exception = Assert.Throws(GetType(ArgumentException), Sub() sut.Borrar(Nothing))
        Assert.Contains(LibroDiario.INVOICE_IS_INVALID_EXCEPTION, exception.Message)
    End Sub

    Private Function CreateSystemUnderTest() As LibroDiario
        Return New LibroDiario()
    End Function

End Class
