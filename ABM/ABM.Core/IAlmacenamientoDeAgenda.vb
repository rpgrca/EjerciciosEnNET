Public interface IAlmacenamientoDeAgenda(Of T)

    Function Contar() As Integer
    Function Agregar(cliente As T) As T
    Function Existe(cliente As T) As Boolean
    Sub Borrar(cliente As T)
    Sub Reemplazar(original As T, reemplazo As T)
    Function Filtrar(Optional nombre As String = "") As List(Of T)

end interface