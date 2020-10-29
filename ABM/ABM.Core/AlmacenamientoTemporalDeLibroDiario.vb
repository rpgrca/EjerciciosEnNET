Friend Class AlmacenamientoTemporalDeLibroDiario
    Implements IAlmacenamientoDeLibroDiario(Of Factura)

    Private ReadOnly _facturas As List(Of Factura)
    Private _nextId As Integer

    Public Sub New()
        _facturas = New List(Of Factura)
        _nextId = 1
    End Sub

    Public Function Contar() As Integer Implements IAlmacenamientoDeLibroDiario(Of Factura).Contar
        Return _facturas.Count
    End Function

    Public Function Agregar(factura As Factura) As Factura Implements IAlmacenamientoDeLibroDiario(Of Factura).Agregar
        Dim facturaModificada = factura.AjustarIdA(_nextId)

        _facturas.Add(facturaModificada)
        _nextId += 1

        Return facturaModificada
    End Function

    public Function Existe(factura As Factura) As Boolean Implements IAlmacenamientoDeLibroDiario(Of Factura).Existe
        Return _facturas.Any(Function(p) p.ConMismoIdQue(factura))
    End Function

    Public Sub Borrar(factura As Factura) Implements IAlmacenamientoDeLibroDiario(Of Factura).Borrar
        _facturas.RemoveAll(Function(p) p.ConMismoIdQue(factura))
    End Sub
    
    Public Sub Reemplazar(original As Factura, reemplazo As Factura) Implements IAlmacenamientoDeLibroDiario(Of Factura).Reemplazar
        _facturas.Remove(original)
        _facturas.Add(reemplazo)
    End Sub

End Class