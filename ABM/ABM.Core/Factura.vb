Public Class Factura

    Public Const CLIENT_IS_INVALID_EXCEPTION As String = Agenda.CLIENT_IS_INVALID_EXCEPTION
    Public Const DATE_IS_INVALID_EXCEPTION As String = "La fecha no puede estar vacia"
    Public Const PRODUCT_IS_INVALID_EXCEPTION As String = "El producto es invalido"
    Public Const QUANTITY_IS_INVALID_EXCEPTION As String = "La cantidad es invalida"

    Private ReadOnly _comprador As Cliente
    Private ReadOnly _fecha As Date
    Private ReadOnly _detalles As List(Of Detalle)

    Public Sub New(comprador As Cliente, fecha As Date)
        If comprador Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        If fecha = Date.MinValue Then Throw New ArgumentException(DATE_IS_INVALID_EXCEPTION)

        _detalles = New List(Of Detalle)
        _comprador = comprador
        _fecha = fecha
    End Sub

    Public Function HechaA(comprador As Cliente) As Boolean
        Return _comprador.ConMismoIdQue(comprador)
    End Function

    Public Function HechaEl(fecha As Date) As Boolean
        Return _fecha = fecha
    End Function

    Public ReadOnly Property Total As Decimal
        Get
            Return _detalles.Sum(Function(d) d.SubTotal)
        End Get
    End Property

    Public Sub Agregar(producto As Producto, unidades As Integer)
        Dim detalle As Detalle = Detalle.Para(producto, unidades)

        detalle.AgregarseA(_detalles)
    End Sub

End Class