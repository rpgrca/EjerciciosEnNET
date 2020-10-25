Public Class Producto

    Private Property Id As Integer
    Private Property Nombre As String
    Private Property Precio As Decimal
    Private Property Codigo As String

    Friend Shared Function De(id As Integer, nombre As String, precio As Decimal, codigo As String) As Producto
        Return New Producto(id, nombre, precio, codigo)
    End Function

    Private Sub New(id As Integer, nombre As String, precio As Decimal, codigo As String)
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException(Inventario.NAME_IS_INVALID_EXCEPTION)
        If precio < 0 Then Throw New ArgumentException(Inventario.PRICE_IS_INVALID_EXCEPTION)
        If String.IsNullOrWhiteSpace(codigo) Then Throw New ArgumentException(Inventario.CODE_IS_INVALID_EXCEPTION)

        Me.Id = id
        Me.Nombre = nombre
        Me.Precio = precio
        Me.Codigo = codigo
    End Sub

    Public Function Nombrado(nombre As String) As Boolean
        Return Me.Nombre = nombre
    End Function

    Public Function ConPrecio(precio As Decimal) As Boolean
        Return True
    End Function

    Public Function ConCodigo(codigo As String) As Boolean
        Return Me.Codigo = codigo
    End Function

    Friend Function ConMismoIdQue(otroProducto As Producto) As Boolean
        Return Id = otroProducto.Id
    End Function

    Public Function CambiarPrecio(nuevoPrecio As Decimal) As Producto
        Return New Producto(Id, Nombre, nuevoPrecio, Codigo)
    End Function

    Public Function CambiarNombre(nuevoNombre As String) As Producto
        Return New Producto(Id, nuevoNombre, Precio, Codigo)
    End Function

    Public Function PrecioPor(cantidad As Integer) As Decimal
        Return Precio * cantidad
    End Function
End Class