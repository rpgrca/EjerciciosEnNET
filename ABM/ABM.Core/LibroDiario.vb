Public Class LibroDiario

    Private ReadOnly _facturas As List(Of Factura)

    public Sub New()
        _facturas = new List(Of Factura)
    End Sub

    Public Function Crear(cliente As Cliente, fecha As Date) As Factura
        Return new Factura(cliente, fecha)
    End Function

    Public Sub Agregar(factura As Factura)
        If factura Is Nothing Then Throw new ArgumentException(Agenda.CLIENT_IS_INVALID_EXCEPTION)
        _facturas.Add(factura)
    End Sub

    Public ReadOnly Property Total As Integer
        Get
            Return _facturas.Count
        End Get
    End Property 
End Class