Public Class Inventario

    Private ReadOnly _productos As List(Of Object)

    Public Sub New()
        _productos = New List(Of Object)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _productos.Count
        End Get
    End Property

    Public Sub Agregar(producto As String)
        _productos.Add(producto)
    End Sub

End Class