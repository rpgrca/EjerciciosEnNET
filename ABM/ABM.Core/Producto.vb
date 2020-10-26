Public Class Producto

    Private ReadOnly Property Id As Integer
    Private ReadOnly Property Nombre As String
    Private ReadOnly Property Precio As Decimal
    Private ReadOnly Property Codigo As String

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
        Return Me.Precio = precio
    End Function

    Public Function ConCodigo(codigo As String) As Boolean
        Return Me.Codigo = codigo
    End Function

    Friend Function ConMismoIdQue(otroProducto As Producto) As Boolean
        Return Id = otroProducto.Id
    End Function

    Friend Function CambiarPrecio(nuevoPrecio As Decimal, inventario As Inventario) As Producto
        Return De(Id, Nombre, nuevoPrecio, Codigo)
    End Function

    Friend Function CambiarNombre(nuevoNombre As String, inventario As Inventario) As Producto
        Return De(Id, nuevoNombre, Precio, Codigo)
    End Function

    Friend Function CambiarCodigo(nuevoCodigo As String, inventario As Inventario) As Producto
        Dim nuevoProducto = De(Id, Nombre, Precio, nuevoCodigo)

        If inventario.Filtrar(, nuevoCodigo).Count > 0 Then
            Throw New ArgumentException(Inventario.CODE_IS_REPEATED_EXCEPTION)
        End If

        Return nuevoProducto
    End Function

    Public Function PrecioPor(cantidad As Integer) As Decimal
        Return Precio * cantidad
    End Function
End Class