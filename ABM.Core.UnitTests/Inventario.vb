Public Class Inventario

    Private _productoAgregado As Boolean

    Public ReadOnly Property Total As Integer
        Get
            If _productoAgregado Then Return 1
            Return 0
        End Get
    End Property

    Public Sub Agregar(producto As String)
        _productoAgregado = True
    End Sub

End Class