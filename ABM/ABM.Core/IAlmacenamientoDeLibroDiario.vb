Public Interface IAlmacenamientoDeInventario(of T)

    Function Contar() As Integer
    Function Agregar(producto As T) As T
    Function Existe(producto As T) As Boolean
    Sub Borrar(producto As T)
    Sub Reemplazar(original As T, reemplazo As T)
    Function Filtrar(Optional nombre As String = "", Optional codigo As String = "") As List(Of T)

End Interface