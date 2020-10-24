Public Class Producto

    Private Property Nombre As String
    Private Property Precio As Decimal
    Private Property Codigo As String

    Public Sub New(nombre As String, precio As Decimal, codigo As String)
        Me.Nombre = nombre
        Me.Precio = precio
        Me.Codigo = codigo
    End Sub

    Public Function Nombrado(nombre As String) As Boolean
        Return True
    End Function

    Public Function ConPrecio(precio As Decimal) As Boolean
        Return True
    End Function

    Public Function ConCodigo(codigo As String) As Boolean
        Return Me.Codigo = codigo
    End Function

    Public Function ConMismoIdQue(otroProducto As Producto) As Boolean
        Return True
    End Function
End Class