Public Class Inventario

    public class Nuevo
        Private _almacenamiento As IAlmacenamientoDeInventario(Of Producto)

        public Shared ReadOnly Property Constructor As Nuevo
            get
                Return New Nuevo()
            End Get
        End Property

        Private sub New()
            _almacenamiento = Nothing
        End sub

        public Function AlmacenandoEn(almacenamiento As IAlmacenamientoDeInventario(Of Producto)) As Nuevo
            _almacenamiento = almacenamiento
            Return Me
        End Function

        public Function Construir() As Inventario
            If _almacenamiento Is Nothing Then _almacenamiento = New AlmacenamientoDeInventario()

            Return new Inventario(_almacenamiento)
        End Function
    End Class

    Public Const NAME_IS_INVALID_EXCEPTION As String = "Nombre de producto inválido"
    Public Const CODE_IS_REPEATED_EXCEPTION As String = "Codigo repetido"
    Public Const PRODUCT_IS_INVALID_EXCEPTION As String = "Producto inexistente"
    Public Const PRICE_IS_INVALID_EXCEPTION As String = "El precio es invalido"
    Public Const CODE_IS_INVALID_EXCEPTION As String = "El codigo es invalido"
    Public Const DEFAULT_CODE As String = "CodigoPorDefecto"

    Private ReadOnly _productos As IAlmacenamientoDeInventario(Of Producto)
    Private _id As Integer

    Public Sub New(productos As IAlmacenamientoDeInventario(Of Producto))
        _productos = productos
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _productos.Contar()
        End Get
    End Property

    Public Function Agregar(nombre As String, Optional precio As Decimal = 0, Optional codigo As String = DEFAULT_CODE) As Producto
        Dim producto As Producto = Producto.De(_id, nombre, precio, codigo)

        If _productos.Filtrar("", codigo).Count > 0 Then Throw New ArgumentException(CODE_IS_REPEATED_EXCEPTION)

        _productos.Agregar(producto)
        _id += 1

        Return producto
    End Function

    Public Sub Borrar(producto As Producto)
        If producto Is Nothing Then Throw New ArgumentException(PRODUCT_IS_INVALID_EXCEPTION)
        If Not _productos.Existe(producto) Then Throw New ArgumentException(PRODUCT_IS_INVALID_EXCEPTION)

        _productos.Borrar(producto)
    End Sub

    Public Function Buscar(nombre As String) As List(Of Producto)
        Return _productos.Buscar(nombre)
    End Function

    Public Function Filtrar(Optional nombre As String = "", Optional codigo As String = "") As List(Of Producto)
        Return _productos.Filtrar(nombre, codigo)
    End Function

    Public Function CambiarCodigoDe(producto As Producto, nuevoCodigo As String) As Producto
        Return CambiarAlgoDe(producto, Function() producto.CambiarCodigo(nuevoCodigo, Me))
    End Function

    Public Function CambiarNombreDe(producto As Producto, nuevoNombre As String) As Producto
        Return CambiarAlgoDe(producto, Function() producto.CambiarNombre(nuevoNombre, Me))
    End Function

    Public Function CambiarPrecioDe(producto As Producto, nuevoPrecio As Integer) As Producto
        Return CambiarAlgoDe(producto, Function() producto.CambiarPrecio(nuevoPrecio, Me))
    End Function

    Private Function CambiarAlgoDe(productoOriginal As Producto, modificarProducto As Func(Of Producto)) As Producto
        Dim productoModificado = modificarProducto()

        _productos.Borrar(productoOriginal)
        _productos.Agregar(productoModificado)

        Return productoModificado
    End Function
End Class