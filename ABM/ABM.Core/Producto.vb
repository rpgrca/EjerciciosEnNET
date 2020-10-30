Public Class Producto
    Implements IEquatable(Of Producto)

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

        If CantidadDeProductosConCodigo(nuevoCodigo, inventario) > 0 Then
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

    Friend Function AgregarseA(almacenamiento As IAlmacenamiento(Of Producto)) As Producto
        Dim cantidadDeProductos = CantidadDeProductosConCodigo(Codigo, almacenamiento)
        If cantidadDeProductos Then Throw new ArgumentException(Inventario.CODE_IS_REPEATED_EXCEPTION)

        Return almacenamiento.Agregar(Me)
    End Function

    Private Function CantidadDeProductosConCodigo(codigoABuscar As String, almacenamiento As IAlmacenamiento(Of Producto)) As Integer
        Dim filtro = New FiltroDeInventario() With { .Codigo = codigoABuscar }
        Return almacenamiento.Filtrar(filtro).Count
    End Function

    Private Function CantidadDeProductosConCodigo(codigoABuscar As String, inventario As Inventario) As Integer
        Dim filtro = New FiltroDeInventario() With { .Codigo = codigoABuscar }
        Return inventario.Filtrar(filtro).Count
    End Function

    Friend Sub BorrarseDe(almacenamiento As IAlmacenamiento(Of Producto))
        If Not almacenamiento.Existe(Me) Then Throw New ArgumentException(Inventario.PRODUCT_IS_INVALID_EXCEPTION)

        almacenamiento.Borrar(Me)
    End Sub

    Friend Function ConfirmarCreacionCon(almacenamiento As IAlmacenamiento(Of Producto)) As Producto
        If CantidadDeProductosConCodigo(Codigo, almacenamiento) > 0 Then Throw New ArgumentException(Inventario.CODE_IS_REPEATED_EXCEPTION)

        Return Me
    End Function

    Public Overloads Function Equals(otroProducto As Producto) As Boolean Implements IEquatable(Of Producto).Equals
        If otroProducto Is Nothing Then Return False
        Return ConMismoIdQue(otroProducto)
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If TypeOf obj IsNot Producto Then Return False

        Dim otroCliente = CType(obj, Producto)

        Return Equals(otroCliente)
    End Function

End Class