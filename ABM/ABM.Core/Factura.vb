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

    Friend Function AjustarIdA(id As Integer) As Factura
        Return Para(id, Comprador, Fecha)
    End Function

    Friend Function ConMismoIdQue(otraFactura As Factura) As Boolean
        Return Id = otraFactura.Id
    End Function

    Friend Function AgregarseA(almacenamiento As IAlmacenamiento(Of Factura)) As Factura
        Return almacenamiento.Agregar(Me)
    End Function

    Friend Sub Borrarse(almacenamiento As IAlmacenamiento(Of Factura))
        If Not almacenamiento.Existe(Me) Then Throw New ArgumentException(LibroDiario.INVOICE_IS_INVALID_EXCEPTION)
        almacenamiento.Borrar(Me)
    End Sub

    Friend Function CambiarFecha(nuevaFecha As Date, libroDiario As LibroDiario) As Factura
        Return Para(Id, Comprador, nuevaFecha)
    End Function

End Class