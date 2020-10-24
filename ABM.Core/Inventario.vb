Public Class Inventario

    Public Const NAME_IS_INVALID_EXCEPTION As String = "Nombre de producto inválido"

    Private ReadOnly _productos As List(Of Object)

    Public Sub New()
        _productos = New List(Of Object)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _productos.Count
        End Get
    End Property

    Public Sub Agregar(nombreDeProducto As Object)
        If String.IsNullOrWhiteSpace(nombreDeProducto) Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)
        _productos.Add(nombreDeProducto)
    End Sub

End Class