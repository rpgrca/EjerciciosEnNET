Public Class Factura
    Public Const CLIENT_IS_INVALID_EXCEPTION As String = "El cliente no puede estar vacio"
    Public Const DATE_IS_INVALID_EXCEPTION As String = "La fecha no puede estar vacia"

    Private ReadOnly _comprador As Cliente

    Public Sub New(comprador As Cliente, fecha As Date)
        _comprador = comprador
        If comprador Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        If fecha = Date.MinValue Then Throw New ArgumentException(DATE_IS_INVALID_EXCEPTION)
    End Sub

    Public Function HechaA(comprador As Cliente) As Boolean
        Return _comprador.ConMismoIdQue(comprador)
    End Function

    Public Function HechaEl(fecha As Date) As Boolean
        Return True
    End Function

    Public Function Total() As Integer
        Return 0
    End Function

End Class