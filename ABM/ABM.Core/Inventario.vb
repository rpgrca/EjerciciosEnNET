Public Class Inventario

    Public Const NAME_IS_INVALID_EXCEPTION As String = "Nombre de producto inválido"
    Public Const CODE_IS_REPEATED_EXCEPTION As String = "Codigo repetido"
    Public Const PRODUCT_IS_INVALID_EXCEPTION As String = "Producto inexistente"
    Public Const PRICE_IS_INVALID_EXCEPTION As String = "El precio es invalido"
    Public Const CODE_IS_INVALID_EXCEPTION As String = "El codigo es invalido"
    Public Const DEFAULT_CODE As String = "CodigoPorDefecto"

    Private ReadOnly _productos As List(Of Producto)
    Private _id As Integer

    Public Sub New()
        _productos = New List(Of Producto)
        _id = 1
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _productos.Count
        End Get
    End Property

    Public Function Agregar(nombre As String, Optional precio As Decimal = 0, Optional codigo As String = DEFAULT_CODE) As Producto
        If _productos.Any(Function(p) p.ConCodigo(codigo)) Then Throw New ArgumentException(CODE_IS_REPEATED_EXCEPTION)

        Dim producto As Producto = Producto.De(_id, nombre, precio, codigo)
        _productos.Add(producto)

        _id += 1
        Return producto
    End Function

    Public Sub Borrar(producto As Producto)
        If producto Is Nothing Then Throw New ArgumentException(PRODUCT_IS_INVALID_EXCEPTION)
        If Not _productos.Any(Function(p) p.ConMismoIdQue(producto)) Then Throw New ArgumentException(PRODUCT_IS_INVALID_EXCEPTION)

        _productos.RemoveAll(Function(p) p.ConMismoIdQue(producto))
    End Sub

    Public Function Buscar(nombre As String) As List(Of Producto)
        Return _productos.Where(Function(p) p.Nombrado(nombre)).ToList()
    End Function

    Public Function Filtrar(Optional nombre As String = "", Optional codigo As String = "") As List(Of Producto)
        Return _productos.Where(Function(p)
                                    Return (String.IsNullOrWhiteSpace(nombre) Or p.Nombrado(nombre)) And
                                           (String.IsNullOrWhiteSpace(codigo) Or p.ConCodigo(codigo))
                                End Function
                                ).ToList()
    End Function

    Private Sub ReemplazarProductoDeInventario(productoExistente As Producto, nuevoProducto As Producto)
        _productos.Remove(productoExistente)
        _productos.Add(nuevoProducto)
    End Sub

    Public Function CambiarCodigoDe(producto As Producto, nuevoCodigo As String) As Producto
        Dim productoModificado = producto.CambiarCodigo(nuevoCodigo, Me)
        ReemplazarProductoDeInventario(producto, productoModificado)

        Return productoModificado
    End Function

    Public Function CambiarNombreDe(producto As Producto, nuevoNombre As String) As Producto
        Dim productoModificado = producto.CambiarNombre(nuevoNombre, Me)
        ReemplazarProductoDeInventario(producto, productoModificado)

        Return productoModificado
    End Function

    Public Function CambiarPrecioDe(producto As Producto, nuevoPrecio As Integer) As Producto
        Dim productoModificado = producto.CambiarPrecio(nuevoPrecio, Me)
        ReemplazarProductoDeInventario(producto, productoModificado)

        Return productoModificado
    End Function
End Class