Public Class Factura

    Public Sub New(comprador As Cliente, fecha As Date)

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