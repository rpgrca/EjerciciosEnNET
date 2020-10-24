Public Class Inventario

    Public Const NAME_IS_INVALID_EXCEPTION As String = "Nombre de producto inválido"

    Private ReadOnly _productos As List(Of Producto)

    Public Sub New()
        _productos = New List(Of Producto)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _productos.Count
        End Get
    End Property

    Public Function Agregar(nombre As String, Optional precio As Decimal = 0, Optional codigo As String = "") As Producto
        If String.IsNullOrWhiteSpace(nombre) Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)

        Dim producto As Producto
        producto = New Producto(nombre, precio, codigo)
        _productos.Add(producto)

        Return producto
    End Function

End Class