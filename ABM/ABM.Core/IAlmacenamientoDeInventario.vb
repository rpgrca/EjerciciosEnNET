Public interface IAlmacenamientoDeInventario(of T)
    Function Contar() As Integer
    Function Agregar(producto As T) As T
    Function Buscar(nombre As String) As List(Of T)
    Function Existe(producto As T) As Boolean
    Sub Borrar(producto As T)
    Sub Reemplazar(original As T, reemplazo As T)
    Function Filtrar(Optional nombre As String = "", Optional codigo As String = "") As List(Of T)
end interface