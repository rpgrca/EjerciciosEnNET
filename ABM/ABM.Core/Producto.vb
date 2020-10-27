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

    Friend Function AjustarIdA(id As Integer) As Producto
        Return De(id, Nombre, Precio, Codigo)
    End Function

    Public Function PrecioPor(cantidad As Integer) As Decimal
        Return Precio * cantidad
    End Function

    Friend Function AgregarseA(almacenamiento As IAlmacenamientoDeInventario(Of Producto)) As Producto
        Dim productos = almacenamiento.Filtrar(, Codigo)
        If productos.Count > 0 Then Throw new ArgumentException(Inventario.CODE_IS_REPEATED_EXCEPTION)

        Return almacenamiento.Agregar(Me)
    End Function

    Friend Sub BorrarseDe(almacenamiento As IAlmacenamientoDeInventario(Of Producto))
        If Not almacenamiento.Existe(Me) Then Throw New ArgumentException(Inventario.PRODUCT_IS_INVALID_EXCEPTION)

        almacenamiento.Borrar(Me)
    End Sub

    Friend Function ConfirmarCreacionCon(almacenamiento As IAlmacenamientoDeInventario(Of Producto)) As Producto
        If almacenamiento.Filtrar(, Codigo).Count > 0 Then Throw New ArgumentException(Inventario.CODE_IS_REPEATED_EXCEPTION)

        Return Me
    End Function
End Class