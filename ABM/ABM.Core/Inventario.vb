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

        'public Function AlmacenandoEn(almacenamiento As IAlmacenamientoDeInventario(Of Producto)) As Nuevo
        '    _almacenamiento = almacenamiento
        '    Return Me
        'End Function

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
    Private _nextId as Integer

    Private Sub New(productos As IAlmacenamientoDeInventario(Of Producto))
        _productos = productos
        _nextId = 0
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _productos.Contar()
        End Get
    End Property

    Public Function Crear(nombre As String, Optional precio As Decimal = 0, Optional codigo As String = DEFAULT_CODE) As Producto
        _nextId -= 1

        Dim producto As Producto = Producto.De(_nextId, nombre, precio, codigo)
        Return producto.ConfirmarCreacionCon(_productos)
    End Function

    public Function Agregar(producto As Producto) As Producto
        If producto Is Nothing Then Throw New ArgumentException(PRODUCT_IS_INVALID_EXCEPTION)
        Return producto.AgregarseA(_productos)
    End Function

    Public Sub Borrar(producto As Producto)
        If producto Is Nothing Then Throw New ArgumentException(PRODUCT_IS_INVALID_EXCEPTION)
        producto.BorrarseDe(_productos)
    End Sub

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

        _productos.Reemplazar(productoOriginal, productoModificado)

        Return productoModificado
    End Function

End Class