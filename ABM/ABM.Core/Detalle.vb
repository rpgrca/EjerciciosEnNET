Friend Class Detalle

    Private ReadOnly _producto As Producto
    Private ReadOnly _unidades As Integer

    Friend Shared Function Para(producto As Producto, unidades As Integer) As Detalle
        Return New Detalle(producto, unidades)
    End Function

    Private Sub New(producto As Producto, unidades As Integer)
        If producto Is Nothing Then Throw New ArgumentException(Factura.PRODUCT_IS_INVALID_EXCEPTION)
        If unidades <= 0 Then Throw New ArgumentException(Factura.QUANTITY_IS_INVALID_EXCEPTION)

        _producto = producto
        _unidades = unidades
    End Sub

    Friend ReadOnly Property SubTotal As Decimal
        Get
            Return _producto.PrecioPor(_unidades)
        End Get
    End Property

    Public Sub AgregarseA(detalles As List(Of Detalle))
        detalles.Add(Me)
    End Sub
End Class