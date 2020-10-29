Public Class LibroDiario

    Public Const INVOICE_IS_INVALID_EXCEPTION As String = "La factura es invalida"

    Private ReadOnly _facturas As List(Of Factura)

    public Sub New()
        _facturas = new List(Of Factura)
    End Sub

    Public Function Crear(cliente As Cliente, fecha As Date) As Factura
        Return new Factura(cliente, fecha)
    End Function

    Public Sub Agregar(factura As Factura)
        If factura Is Nothing Then Throw new ArgumentException(INVOICE_IS_INVALID_EXCEPTION)
        _facturas.Add(factura)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _facturas.Count
        End Get
    End Property

    Public Sub Borrar(factura As Factura)
        If factura Is Nothing Then Throw New ArgumentException(INVOICE_IS_INVALID_EXCEPTION)
        If Not _facturas.Contains(factura) Then Throw New ArgumentException(INVOICE_IS_INVALID_EXCEPTION)
        _facturas.Remove(factura)
    End Sub
End Class