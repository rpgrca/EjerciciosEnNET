Public Class Inventario

    Public Const NAME_IS_INVALID_EXCEPTION As String = "Nombre de producto inválido"
    Public Const CODE_IS_REPEATED_EXCEPTION As String = "Codigo repetido"
    Public Const PRODUCT_IS_INVALID_EXCEPTION As String = "Producto inexistente"

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

    Public Function Agregar(nombre As String, Optional precio As Decimal = 0, Optional codigo As String = "") As Producto
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)
        If _productos.Any(Function(p) p.ConCodigo(codigo)) Then Throw New ArgumentException(CODE_IS_REPEATED_EXCEPTION)

        Dim producto As Producto
        producto = New Producto(_id, nombre, precio, codigo)
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
        Return _productos
    End Function
End Class