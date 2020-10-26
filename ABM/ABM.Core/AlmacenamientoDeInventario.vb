Friend Class AlmacenamientoDeInventario
    Implements IAlmacenamientoDeInventario(Of Producto)

    Private ReadOnly _productos As List(Of Producto)

    Public Sub New()
        _productos = New List(Of Producto)
    End Sub

    Public Function Contar() As Integer Implements IAlmacenamientoDeInventario(Of Producto).Contar
        Return _productos.Count
    End Function

    Public Sub Agregar(productoNuevo As Producto) Implements IAlmacenamientoDeInventario(Of Producto).Agregar
        _productos.Add(productoNuevo)
    End Sub

    Public Function Buscar(nombre As String) As List(Of Producto) Implements IAlmacenamientoDeInventario(Of Producto).Buscar
        Return _productos.Where(Function(p) p.Nombrado(nombre)).ToList()
    End Function

    public Function Existe(producto As Producto) As Boolean Implements IAlmacenamientoDeInventario(Of Producto).Existe
        Return _productos.Any(Function(p) p.ConMismoIdQue(producto))
    End Function

    Public Sub Borrar(producto As Producto) Implements IAlmacenamientoDeInventario(Of Producto).Borrar
        _productos.RemoveAll(Function(p) p.ConMismoIdQue(producto))
    End Sub

    Public Function Filtrar(nombre As String, codigo As String) As List(Of Producto) Implements IAlmacenamientoDeInventario(Of Producto).Filtrar
        Return _productos.Where(Function(p)
            Return (String.IsNullOrWhiteSpace(nombre) Or p.Nombrado(nombre)) And (String.IsNullOrWhiteSpace(codigo) Or p.ConCodigo(codigo))
        End Function).ToList()
    End Function
End Class