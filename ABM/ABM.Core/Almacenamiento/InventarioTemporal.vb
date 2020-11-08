Namespace Almacenamiento

    Friend Class InventarioTemporal
        Implements IAlmacenamiento(Of Producto)

        Private ReadOnly _productos As List(Of Producto)
        Private _nextId As Integer

        Public Sub New()
            _productos = New List(Of Producto)
            _nextId = 1
        End Sub

        Public Function Contar() As Integer Implements IAlmacenamiento(Of Producto).Contar
            Return _productos.Count
        End Function

        Public Function Agregar(producto As Producto) As Producto Implements IAlmacenamiento(Of Producto).Agregar
            Dim productoModificado As Producto = producto.AjustarIdA(_nextId)

            _productos.Add(productoModificado)
            _nextId += 1

            Return productoModificado
        End Function

        public Function Existe(producto As Producto) As Boolean Implements IAlmacenamiento(Of Producto).Existe
            Return _productos.Any(Function(p) p.ConMismoIdQue(producto))
        End Function

        Public Sub Borrar(producto As Producto) Implements IAlmacenamiento(Of Producto).Borrar
            _productos.RemoveAll(Function(p) p.ConMismoIdQue(producto))
        End Sub

        Public Function Filtrar(filtro As IFiltroDeAlmacenamiento(Of Producto)) As List(Of Producto) Implements IAlmacenamiento(Of Producto).Filtrar
            Dim filtroDeInventario As FiltroDeInventario = CType(filtro, FiltroDeInventario)

            Return _productos.Where(Function(p)
                Return (String.IsNullOrWhiteSpace(filtroDeInventario.Nombre) Or p.Nombrado(filtroDeInventario.Nombre)) And (String.IsNullOrWhiteSpace(filtroDeInventario.Codigo) Or p.ConCodigo(filtroDeInventario.Codigo))
            End Function).ToList()
        End Function

        Public Sub Reemplazar(original As Producto, reemplazo As Producto) Implements IAlmacenamiento(Of Producto).Reemplazar
            _productos.Remove(original)
            _productos.Add(reemplazo)
        End Sub
    End Class
End NameSpace