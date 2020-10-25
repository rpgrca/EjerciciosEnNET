Public Class Detalle

    Private ReadOnly _producto As Producto
    Private ReadOnly _unidades As Integer

    Friend Shared Function Para(producto As Producto, unidades As Integer) As Detalle
        Return New Detalle(producto, unidades)
    End Function

    Private Sub New(producto As Producto, unidades As Integer)
        _producto = producto
        _unidades = unidades
    End Sub

    Public ReadOnly Property SubTotal
        Get
            Return _producto.PrecioPor(_unidades)
        End Get
    End Property

End Class