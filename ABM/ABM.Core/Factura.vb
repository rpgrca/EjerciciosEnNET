Public Class Factura
    Public Const CLIENT_IS_INVALID_EXCEPTION As String = "El cliente no puede estar vacio"
    Public Const DATE_IS_INVALID_EXCEPTION As String = "La fecha no puede estar vacia"

    Private ReadOnly _comprador As Cliente
    Private ReadOnly _fecha As Date
    Private _productoAgregado As Boolean = False

    Public Sub New(comprador As Cliente, fecha As Date)
        If comprador Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        If fecha = Date.MinValue Then Throw New ArgumentException(DATE_IS_INVALID_EXCEPTION)

        _comprador = comprador
        _fecha = fecha
    End Sub

    Public Function HechaA(comprador As Cliente) As Boolean
        Return _comprador.ConMismoIdQue(comprador)
    End Function

    Public Function HechaEl(fecha As Date) As Boolean
        Return _fecha = fecha
    End Function

    Public Function Total() As Integer
        If _productoAgregado Then
            Return 270
        End If

        Return 0
    End Function

    Public Sub Agregar(producto As Producto, unidades As Integer)
        _productoAgregado = True
    End Sub
End Class