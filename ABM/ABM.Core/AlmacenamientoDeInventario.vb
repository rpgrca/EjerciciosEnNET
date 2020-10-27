Friend Class AlmacenamientoDeInventario
    Implements IAlmacenamientoDeInventario(Of Producto)

    Private ReadOnly _productos As List(Of Producto)
    Private _nextId As Integer

    Public Sub New()
        _productos = New List(Of Producto)
        _nextId = 1
    End Sub

    Public Function Contar() As Integer Implements IAlmacenamientoDeInventario(Of Producto).Contar
        Return _productos.Count
    End Function

    Public Function Agregar(producto As Producto) As Producto Implements IAlmacenamientoDeInventario(Of Producto).Agregar
        Dim productoModificado = producto.AjustarIdA(_nextId)

        _productos.Add(productoModificado)
        _nextId += 1

        Return productoModificado
    End Function

    Public Function Buscar(nombre As String) As List(Of Producto) Implements IAlmacenamientoDeInventario(Of Producto).Buscar
        Return _productos.Where(Function(p) p.Nombrado(nombre)).ToList()
    End Function

    public Function Existe(producto As Producto) As Boolean Implements IAlmacenamientoDeInventario(Of Producto).Existe
        Return _productos.Any(Function(p) p.ConMismoIdQue(producto))
    End Function

    Public Sub Borrar(producto As Producto) Implements IAlmacenamientoDeInventario(Of Producto).Borrar
        _productos.RemoveAll(Function(p) p.ConMismoIdQue(producto))
    End Sub

    Public Function Filtrar(Optional nombre As String = "", Optional codigo As String = "") As List(Of Producto) Implements IAlmacenamientoDeInventario(Of Producto).Filtrar
        Return _productos.Where(Function(p)
            Return (String.IsNullOrWhiteSpace(nombre) Or p.Nombrado(nombre)) And (String.IsNullOrWhiteSpace(codigo) Or p.ConCodigo(codigo))
        End Function).ToList()
    End Function

    Public Sub Reemplazar(original As Producto, reemplazo As Producto) Implements IAlmacenamientoDeInventario(Of Producto).Reemplazar
        _productos.Remove(original)
        _productos.Add(reemplazo)
    End Sub
End Class