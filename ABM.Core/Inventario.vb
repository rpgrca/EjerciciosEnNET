Public Class Inventario

    Private ReadOnly _productos As List(Of Object)
    Public Const NAME_IS_INVALID_EXCEPTION As String = "Nombre de producto inválido"

    Public Sub New()
        _productos = New List(Of Object)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _productos.Count
        End Get
    End Property

    Public Sub Agregar(producto As String)
        If String.IsNullOrWhiteSpace(producto) Then Throw New ArgumentException(NAME_IS_INVALID_EXCEPTION)
        _productos.Add(producto)
    End Sub

End Class