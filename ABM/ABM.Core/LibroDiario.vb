Public Class LibroDiario

    public class Nuevo
        Private _almacenamiento As IAlmacenamiento(Of Factura)

        public Shared ReadOnly Property Constructor As Nuevo
            get
                Return New Nuevo()
            End Get
        End Property

        Private sub New()
            _almacenamiento = Nothing
        End sub

        public Function Construir() As LibroDiario
            If _almacenamiento Is Nothing Then _almacenamiento = New AlmacenamientoTemporalDeLibroDiario()

            Return new LibroDiario(_almacenamiento)
        End Function
    End Class

    Public Const INVOICE_IS_INVALID_EXCEPTION As String = "La factura es invalida"

    Private ReadOnly _facturas As IAlmacenamiento(Of Factura)
    Private _nextId as Integer

    private Sub New(facturas As IAlmacenamiento(Of Factura))
        _facturas = facturas
        _nextId = 0
    End Sub

    Public Function Crear(cliente As Cliente, fecha As Date) As Factura
        _nextId -= 1
        Return Factura.Para(_nextId, cliente, fecha)
    End Function

    Public Function Agregar(factura As Factura) As Factura
        If factura Is Nothing Then Throw new ArgumentException(INVOICE_IS_INVALID_EXCEPTION)
        Return factura.AgregarseA(_facturas)
    End Function

    Public ReadOnly Property Total As Integer
        Get
            Return _facturas.Contar()
        End Get
    End Property

    Public Sub Borrar(factura As Factura)
        If factura Is Nothing Then Throw New ArgumentException(INVOICE_IS_INVALID_EXCEPTION)
        factura.Borrarse(_facturas)
    End Sub

    Public Function CambiarFechaDe(factura As Factura, nuevaFecha As Date) As Factura
        Return CambiarAlgoDe(factura, Function() factura.CambiarFecha(nuevaFecha, Me))
    End Function

    Private Function CambiarAlgoDe(facturaOriginal As Factura, modificarFactura As Func(Of Factura)) As Factura
        Dim facturaModificada = modificarFactura()

        _facturas.Reemplazar(facturaOriginal, facturaModificada)

        Return facturaModificada
    End Function

End Class