Public Class Factura

    Public Const CLIENT_IS_INVALID_EXCEPTION As String = Agenda.CLIENT_IS_INVALID_EXCEPTION
    Public Const DATE_IS_INVALID_EXCEPTION As String = "La fecha no puede estar vacia"
    Public Const PRODUCT_IS_INVALID_EXCEPTION As String = "El producto es invalido"
    Public Const QUANTITY_IS_INVALID_EXCEPTION As String = "La cantidad es invalida"

    Private ReadOnly Property Comprador As Cliente
    Private ReadOnly Property Fecha As Date
    Private ReadOnly Property Detalles As List(Of Detalle)
    Private ReadOnly Property Id As Integer

    Friend Shared Function Para(id As Integer, cliente As Cliente, fecha As Date) As Factura
        Return New Factura(id, cliente, fecha)
    End Function

    Private Sub New(id As Integer, comprador As Cliente, fecha As Date)
        If comprador Is Nothing Then Throw New ArgumentException(CLIENT_IS_INVALID_EXCEPTION)
        If fecha = Date.MinValue Then Throw New ArgumentException(DATE_IS_INVALID_EXCEPTION)

        Detalles = New List(Of Detalle)
        Me.Comprador = comprador
        Me.Fecha = fecha
        Me.Id = id
    End Sub

    Public Function HechaA(comprador As Cliente) As Boolean
        Return Me.Comprador.ConMismoIdQue(comprador)
    End Function

    Public Function HechaEl(fecha As Date) As Boolean
        Return Me.Fecha = fecha
    End Function

    Public ReadOnly Property Total As Decimal
        Get
            Return Detalles.Sum(Function(d) d.SubTotal)
        End Get
    End Property

    Public Sub Agregar(producto As Producto, unidades As Integer)
        Dim detalle As Detalle = Detalle.Para(producto, unidades)

        detalle.AgregarseA(Detalles)
    End Sub

    Public Function AjustarIdA(id As Integer) As Factura
        Return Para(id, Comprador, Fecha)
    End Function

    Public Function ConMismoIdQue(otraFactura As Factura) As Boolean
        Return Id = otraFactura.Id
    End Function
End Class