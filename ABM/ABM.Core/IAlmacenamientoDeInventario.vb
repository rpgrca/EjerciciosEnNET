Public interface IAlmacenamientoDeInventario(of T)
    Function Contar() As Integer
    Sub Agregar(productoNuevo As T)
    Function Buscar(nombre As String) As List(Of T)
    Function Existe(producto As T) As Boolean
    Sub Borrar(producto As T)
    Function Filtrar(nombre As String, codigo As String) As List(Of T)
end interface