Public Class LibroDiario

    public class Nuevo
        Private _almacenamiento As IAlmacenamientoDeLibroDiario(Of Factura)

        public Shared ReadOnly Property Constructor As Nuevo
            get
                Return New Nuevo()
            End Get
        End Property

        Private sub New()
            _almacenamiento = Nothing
        End sub

        public Function Construir() As LibroDiario
            If _almacenamiento Is Nothing Then _almacenamiento = New AlmacenamientoDeLibroDiario()

            Return new LibroDiario(_almacenamiento)
        End Function
    End Class

    Public Const INVOICE_IS_INVALID_EXCEPTION As String = "La factura es invalida"

    Private ReadOnly _facturas As List(Of Factura)
    Private _nextId as Integer

    private Sub New(facturas As IAlmacenamientoDeLibroDiario(Of Factura))
        _facturas = new List(Of Factura)
        _nextId = 0
    End Sub

    Public Function Crear(cliente As Cliente, fecha As Date) As Factura
        _nextId -= 1
        Return Factura.Para(_nextId, cliente, fecha)
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