Public Class Factura
    Public Const CLIENT_IS_INVALID_EXCEPTION As String = "Client"

    Public Sub New(comprador As Cliente, fecha As Date)
        If comprador Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
    End Sub

    Public Function HechaA(comprador As Cliente) As Boolean
        Return True
    End Function

    Public Function HechaEl(fecha As Date) As Boolean
        Return True
    End Function

    Public Function Total() As Integer
        Return 0
    End Function

End Class